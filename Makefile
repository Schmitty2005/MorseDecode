.PHONY: clean All

All:
	@echo "----------Building project:[ MorseTesting - Debug ]----------"
	@$(MAKE) -f  "MorseTesting.mk"
clean:
	@echo "----------Cleaning project:[ MorseTesting - Debug ]----------"
	@$(MAKE) -f  "MorseTesting.mk" clean
