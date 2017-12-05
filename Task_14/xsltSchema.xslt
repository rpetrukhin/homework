<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="building">
    <building>  
	  <xsl:apply-templates/>
    </building>
  </xsl:template>
  
  <xsl:template match="floor">
    <floor>
      <xsl:attribute name="number">
        <xsl:value-of select="@number"/>
      </xsl:attribute>
	  <xsl:apply-templates/>
    </floor>
  </xsl:template>
  
  <xsl:template match="flats">
    <flats>
      <xsl:apply-templates/>
    </flats>
  </xsl:template>
  
  <xsl:template match="flat">
    <flat>
      <xsl:attribute name="number">
        <xsl:value-of select="."/>
      </xsl:attribute>
    </flat>
  </xsl:template>
  
</xsl:stylesheet> 