parser grammar DslParser;

options { tokenVocab=DslLexer; }

dsl_batch: script*;

script:
    get_all |
    get_simple | 
    then_logic | 
    end_script;

get_all: GET ASTERIKS;
get_simple: GET ID (COMMA ID)*;
then_logic: THEN built_in_function;

built_in_function:
    send_email;
    
send_email: 
    SEND_EMAIL LEFT_PAREN message=STRING RIGHT_PAREN;   
    
end_script: END;