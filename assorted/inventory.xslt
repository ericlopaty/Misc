<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  version="1.0">

  <xsl:output method="html"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Angus Hardware | Online Catalog</title>
      </head>
      <xsl:apply-templates/>
    </html>
  </xsl:template>

  <xsl:template match="inventory">
    <body bgcolor="#FFFFFF">
      <h1>Angus Hardware</h1>
      <h2>Online Catalog</h2>
      <xsl:apply-templates/>
    </body>
  </xsl:template>

  <xsl:template match="date">
    <p>Current as of 
      <xsl:value-of select="@month" />/<xsl:value-of select="@day" />/<xsl:value-of select="@year" />
</p>
  </xsl:template>

  <xsl:template match="items">
    <p>Currently available items:</p>
    <table border="1">
      <tr>
        <th>Product Code</th>
        <th>Description</th>
        <th>Unit Price</th>
        <th>Quantity in Stock</th>
      </tr>
      <xsl:apply-templates />
    </table>
  </xsl:template>

  <xsl:template match="item">
    <tr>
      <td><xsl:value-of select="@productCode" /></td>
      <td><xsl:value-of select="@description" /></td>
      <td><xsl:value-of select="@unitCost" /></td>
      <td><xsl:value-of select="@quantity" /></td>
    </tr>
</xsl:template>

</xsl:stylesheet>
