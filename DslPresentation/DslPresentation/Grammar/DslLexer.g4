lexer grammar DslLexer;

GET: 'GET';
THEN: 'THEN'; 
SEND_EMAIL: 'SEND_EMAIL';
END: 'END';

ASTERIKS: '*';
COMMA: ',';
LEFT_PAREN: '(';
RIGHT_PAREN: ')';

ID : [a-zA-Z_]+;
STRING: '"' ~'"'+ '"';
NUMBER: [0-9]+;

SPACES: [ \t\r\n]+ -> channel(HIDDEN);