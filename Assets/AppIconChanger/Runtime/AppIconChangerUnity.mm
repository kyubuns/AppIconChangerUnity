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
		if ([nsstringText  isEqual: @""]) nsstringText = nil;
		[[UIApplication sharedApplication] setAlternateIconName:nsstringText completionHandler:^(NSError * _Nullable error)
		{
			if (error != nil)
			{
				NSLog(@"_SetAlternateIconName.Error %@", error);
			}
		}];
	}
}

