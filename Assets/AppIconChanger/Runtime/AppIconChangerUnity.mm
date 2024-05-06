NSString* AppIconChanger_CreateNSString(const char* string)
{
	return [NSString stringWithUTF8String: string ? string : ""];
}

char* AppIconChanger_MakeStringCopy(const char* string)
{
	if (string == NULL) return NULL;
	char* res = (char*)malloc(strlen(string) + 1);
	strcpy(res, string);
	return res;
}

extern "C"
{
	bool _SupportsAlternateIcons()
	{
		return [[UIApplication sharedApplication] supportsAlternateIcons];
	}

	char *_AlternateIconName()
	{
		NSString *string = [[UIApplication sharedApplication] alternateIconName];
		return AppIconChanger_MakeStringCopy([string UTF8String]);
	}

	void _SetAlternateIconName(const char* iconName)
	{
		NSString *nsstringText = AppIconChanger_CreateNSString(iconName);

		// https://stackoverflow.com/a/49730130/4836063
		if ([[UIApplication sharedApplication] respondsToSelector:@selector(supportsAlternateIcons)] && [[UIApplication sharedApplication] supportsAlternateIcons])
		{
			NSMutableString *selectorString = [[NSMutableString alloc] initWithCapacity:40];
			[selectorString appendString:@"_setAlternate"];
			[selectorString appendString:@"IconName:"];
			[selectorString appendString:@"completionHandler:"];

			SEL selector = NSSelectorFromString(selectorString);
			IMP imp = [[UIApplication sharedApplication] methodForSelector:selector];
			void (*func)(id, SEL, id, id) = (void (*)(id, SEL, id, id))imp;
			if (func)
			{
				func([UIApplication sharedApplication], selector, nsstringText, ^(NSError * _Nullable error) {});
			}
		}
	}
}

