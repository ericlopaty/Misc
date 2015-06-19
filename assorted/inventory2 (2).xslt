<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  version="1.0">
  
  <xsl:output method="text" />
  
  <xsl:template match="/">
Angus Hardware
Inventory Summary
========= =======

There are <xsl:value-of select="sum(/inventory/items/item/@quantity)" /> units in stock.
  </xsl:template>
</xsl:stylesheet>
