function ValidateUrl(url: string): boolean;

var isHttps : boolean;

begin
	url := Uppercase(url);

	if Length(url) >= 5 then
	begin
		isHttps := url[5] = 'S';
	end;

	if isHttps then
	begin
		Result :=
		(Length(url) > 8) and
		(url[1] = 'H') and 
		(url[2] = 'T') and
		(url[3] = 'T') and
		(url[4] = 'P') and
		(url[6] = ':') and
		(url[7] = '/') and
		(url[8] = '/');
	end
	else
	begin
		Result :=
		(Length(url) > 7) and
		(url[1] = 'H') and 
		(url[2] = 'T') and
		(url[3] = 'T') and
		(url[4] = 'P') and
		(url[5] = ':') and
		(url[6] = '/') and
		(url[7] = '/');
	end;
end;