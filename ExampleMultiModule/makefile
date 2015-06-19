# csc /nologo /debug+ /d:DEBUG /d:TRACE /t:module /r:System.dll /keyfile:keyfile.snk /out:.\bin\Fraction.dll Fraction.cs
# csc /nologo /debug+ /d:DEBUG /d:TRACE /t:module /r:System.dll /keyfile:keyfile.snk /out:.\bin\Calc.dll Calc.cs
# csc /nologo /debug+ /d:DEBUG /d:TRACE /t:library /addmodule:.\bin\Fraction.dll;.\bin\Calc.dll /keyfile:keyfile.snk /out:.\bin\MySharedAssembly.dll .\AssemblyInfo.cs

ASSEMBLY= MySharedAssembly.dll

BIN=.\bin
SRC=.
DEST=.\bin

CSC=csc /nologo /debug+ /d:DEBUG /d:TRACE

MODULETARGET=/t:module
LIBTARGET=/t:library

EXETARGET=/t:exe

REFERENCES=System.dll

MODULES=$(DEST)\Fraction.dll $(DEST)\Calc.dll
METADATA=$(SRC)\AssemblyInfo.cs

all: $(DEST)\MySharedAssembly.dll

# Assembly metadata placed in same module as manifest
$(DEST)\$(ASSEMBLY): $(METADATA) $(MODULES) $(DEST)
	$(CSC) $(LIBTARGET) /addmodule:$(MODULES: =;) /keyfile:keyfile.snk /out:$@ %s

# Add Calc.dll module to this dependency list
$(DEST)\Calc.dll: Calc.cs $(DEST)
	$(CSC) $(MODULETARGET) /r:$(REFERENCES: =;) /keyfile:keyfile.snk /out:$@ %s

# Add Fraction
$(DEST)\Fraction.dll: Fraction.cs $(DEST)
	$(CSC) $(MODULETARGET) /r:$(REFERENCES: =;) /keyfile:keyfile.snk /out:$@ %s

$(DEST)::
!if !EXISTS($(DEST))
	mkdir $(DEST)
!endif
