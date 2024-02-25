#TERMINAL_FILE
TITLE=XSS Test
```

Testing direct XSS
<script>alert('XSS');</script>

Testing escape from color tag
[color=red"><script>alert('XSS');</script>][/color]

Button XSS test
[button=javascript:alert('XSS');Click me]

```

This is a test file used to test XSS vulnerabilities. Never link to this file in any way.