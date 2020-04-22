#### Match only alphanumeric characters along with the characters -, +, ., and any whitespace:

^([\w\.\+\-]|\s)*$

#### Match only alphanumeric characters along with the characters -, +, ., and any whitespace, with the stipulation that there is at least one of these characters and no more than 10 of these characters:

^([\w\.\+\-]|\s){1,10}$

#### Match a person’s name, up to 55 characters:

^[a-zA-Z\'\-\s]{1,55}$

#### Match a positive or negative integer:

^(\+|\-)?\d+$

#### Match a positive or negative floating-point number only; this pattern does not match integers:

^(\+|\-)?(\d*\.\d+)$

#### Match a floating-point or integer number that can have a positive or negative value:

^(\+|\-)?(\d*\.)?\d+$

#### Match a date in the form ##/##/####, where the day and month can be a one- or twodigit value and the year can only be a four-digit value:

^\d{1,2}\/\d{1,2}\/\d{4}$

#### Verify if the input is a Social Security number of the form ###-##-####:

^\d{3}-\d{2}-\d{4}$

#### Match an IPv4 address:

^([0-2]?[0-9]?[0-9]\.){3}[0-2]?[0-9]?[0-9]$

#### Verify that an email address is in the form name@address where address is not an IP address:

^[A-Za-z0-9_\-\.]+@(([A-Za-z0-9\-])+\.)+([A-Za-z\-])+$

#### Verify that an email address is in the form name@address where address is an IP address:

^[A-Za-z0-9_\-\.]+@([0-2]?[0-9]?[0-9]\.){3}[0-2]?[0-9]?[0-9]$

#### Match or verify a URL that uses either the HTTP, HTTPS, or FTP protocol. Note that this regular expression will not match relative URLs:

^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&%\$#\=~])*$

#### Match only a dollar amount with the optional $ and + or - preceding characters (note that any number of decimal places may be added):

^\$?[+-]?[\d,]*(\.\d*)?$

#### This is similar to the previous regular expression, except that no more than two decimal places are allowed:

^\$?[+-]?[\d,]*\.?\d{0,2}$

#### Match a credit card number to be entered as four sets of four digits separated with a space, -, or no character at all:

^((\d{4}[- ]?){3}\d{4})$

#### Match a zip code to be entered as five digits with an optional four-digit extension:

^\d{5}(-\d{4})?$

#### Match a North American phone number with an optional area code and an optional - character to be used in the phone number and no extension:

^(\(?[0-9]{3}\)?)?\-?[0-9]{3}\-?[0-9]{4}$

#### Match a phone number similar to the previous regular expression but allow an optional five-digit extension prefixed with either ext or extension:

^(\(?[0-9]{3}\)?)?\-?[0-9]{3}\-?[0-9]{4}(\s*ext(ension)?[0-9]{5})?$

#### Match a full path beginning with the drive letter and optionally match a filename with a three-character extension (note that no .. characters signifying to move up the directory hierarchy are allowed, nor is a directory name with a . followed by an extension):

^[a-zA-Z]:[\\/]([_a-zA-Z0-9]+[\\/]?)*([_a-zA-Z0-9]+\.[_a-zA-Z0-9]{0,3})?$

#### Verify if the input password string matches some specific rules for entering a password (i.e., the password is between 6 and 25 characters in length and contains alphanumeric characters):

^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,25}$

#### Determine if any malicious characters were input by the user. Note that this regular expression will not prevent all malicious input, and it also prevents some valid input, such as last names that contain a single quote:

^([^\)\(\<\>\"\'\%\&\+\;][(-{2})])*$

#### Extract a tag from an XHTML, HTML, or XML string. This regular expression will return the beginning tag and ending tag, including any attributes of the tag. Note that you will need to replace TAGNAME with the real tag name you want to search for:

<TAGNAME.*?>(.*?)</TAGNAME>

#### Extract a comment line from code. The following regular expression extracts HTML comments from a web page. This can be useful in determining if any HTML comments that are leaking sensitive information need to be removed from your code base before it goes into production:

<!--.*?-->

#### Match a C# single-line comment:

//.*$

#### Match a C# multiline comment:

/\*.*?\*/

