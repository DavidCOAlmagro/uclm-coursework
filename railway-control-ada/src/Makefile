DIROBJ := obj/
DIREXE := exec/

CC := gnatmake
CFLAGS := -gnatwa

MAIN := main


all: dirs $(DIREXE)$(MAIN)

dirs:
	mkdir -p $(DIROBJ) $(DIREXE)

$(DIREXE)$(MAIN): main.adb | dirs
	$(CC) $(CFLAGS) $< -o $@
	
exec: $(DIREXE)$(MAIN)
	clear && ./$(DIREXE)$(MAIN) // Clear the terminal and run the executable
clean:
	rm -rf *~ core obj/ exec/