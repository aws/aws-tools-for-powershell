/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CloudSearch;
using Amazon.CloudSearch.Model;

namespace Amazon.PowerShell.Cmdlets.CS
{
    /// <summary>
    /// Configures an <code><a>IndexField</a></code> for the search domain. Used to create
    /// new fields and modify existing ones. You must specify the name of the domain you are
    /// configuring and an index field configuration. The index field configuration specifies
    /// a unique name, the index field type, and the options you want to configure for the
    /// field. The options you can specify depend on the <code><a>IndexFieldType</a></code>.
    /// If the field exists, the new configuration replaces the old one. For more information,
    /// see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-index-fields.html" target="_blank">Configuring Index Fields</a> in the <i>Amazon CloudSearch Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Set", "CSIndexField", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudSearch.Model.IndexFieldStatus")]
    [AWSCmdlet("Invokes the DefineIndexField operation against Amazon CloudSearch.", Operation = new[] {"DefineIndexField"})]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.IndexFieldStatus",
        "This cmdlet returns a IndexFieldStatus object.",
        "The service call response (type Amazon.CloudSearch.Model.DefineIndexFieldResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCSIndexFieldCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        #region Parameter TextArrayOptions_AnalysisScheme
        /// <summary>
        /// <para>
        /// <para>The name of an analysis scheme for a <code>text-array</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextArrayOptions_AnalysisScheme")]
        public System.String TextArrayOptions_AnalysisScheme { get; set; }
        #endregion
        
        #region Parameter TextOptions_AnalysisScheme
        /// <summary>
        /// <para>
        /// <para>The name of an analysis scheme for a <code>text</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextOptions_AnalysisScheme")]
        public System.String TextOptions_AnalysisScheme { get; set; }
        #endregion
        
        #region Parameter DateArrayOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateArrayOptions_DefaultValue")]
        public System.String DateArrayOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter DateOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateOptions_DefaultValue")]
        public System.String DateOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter DoubleArrayOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleArrayOptions_DefaultValue")]
        public System.Double DoubleArrayOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter DoubleOptions_DefaultValue
        /// <summary>
        /// <para>
        /// <para>A value to use for the field if the field isn't specified for a document. This can
        /// be important if you are using the field in an expression and that field is not present
        /// in every document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleOptions_DefaultValue")]
        public System.Double DoubleOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter IntArrayOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntArrayOptions_DefaultValue")]
        public System.Int64 IntArrayOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter IntOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document. This can be important if you are using the field in
        /// an expression and that field is not present in every document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntOptions_DefaultValue")]
        public System.Int64 IntOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter LatLonOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LatLonOptions_DefaultValue")]
        public System.String LatLonOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter LiteralArrayOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralArrayOptions_DefaultValue")]
        public System.String LiteralArrayOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter LiteralOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralOptions_DefaultValue")]
        public System.String LiteralOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter TextArrayOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextArrayOptions_DefaultValue")]
        public System.String TextArrayOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter TextOptions_DefaultValue
        /// <summary>
        /// <para>
        /// A value to use for the field if the field
        /// isn't specified for a document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextOptions_DefaultValue")]
        public System.String TextOptions_DefaultValue { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DateArrayOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateArrayOptions_FacetEnabled")]
        public System.Boolean DateArrayOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter DateOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateOptions_FacetEnabled")]
        public System.Boolean DateOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter DoubleArrayOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleArrayOptions_FacetEnabled")]
        public System.Boolean DoubleArrayOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter DoubleOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleOptions_FacetEnabled")]
        public System.Boolean DoubleOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter IntArrayOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntArrayOptions_FacetEnabled")]
        public System.Boolean IntArrayOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter IntOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntOptions_FacetEnabled")]
        public System.Boolean IntOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter LatLonOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LatLonOptions_FacetEnabled")]
        public System.Boolean LatLonOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter LiteralArrayOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralArrayOptions_FacetEnabled")]
        public System.Boolean LiteralArrayOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter LiteralOptions_FacetEnabled
        /// <summary>
        /// <para>
        /// <para>Whether facet information can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralOptions_FacetEnabled")]
        public System.Boolean LiteralOptions_FacetEnabled { get; set; }
        #endregion
        
        #region Parameter TextArrayOptions_HighlightEnabled
        /// <summary>
        /// <para>
        /// <para>Whether highlights can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextArrayOptions_HighlightEnabled")]
        public System.Boolean TextArrayOptions_HighlightEnabled { get; set; }
        #endregion
        
        #region Parameter TextOptions_HighlightEnabled
        /// <summary>
        /// <para>
        /// <para>Whether highlights can be returned for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextOptions_HighlightEnabled")]
        public System.Boolean TextOptions_HighlightEnabled { get; set; }
        #endregion
        
        #region Parameter IndexField_IndexFieldName
        /// <summary>
        /// <para>
        /// <para>A string that represents the name of an index field. CloudSearch supports regular
        /// index fields as well as dynamic fields. A dynamic field's name defines a pattern that
        /// begins or ends with a wildcard. Any document fields that don't map to a regular index
        /// field but do match a dynamic field's pattern are configured with the dynamic field's
        /// indexing options. </para><para>Regular field names begin with a letter and can contain the following characters:
        /// a-z (lowercase), 0-9, and _ (underscore). Dynamic field names must begin or end with
        /// a wildcard (*). The wildcard can also be the only character in a dynamic field name.
        /// Multiple wildcards, and wildcards embedded within a string are not supported. </para><para>The name <code>score</code> is reserved and cannot be used as a field name. To reference
        /// a document's ID, you can use the name <code>_id</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IndexField_IndexFieldName { get; set; }
        #endregion
        
        #region Parameter IndexField_IndexFieldType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudSearch.IndexFieldType")]
        public Amazon.CloudSearch.IndexFieldType IndexField_IndexFieldType { get; set; }
        #endregion
        
        #region Parameter DateArrayOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateArrayOptions_ReturnEnabled")]
        public System.Boolean DateArrayOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter DateOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateOptions_ReturnEnabled")]
        public System.Boolean DateOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter DoubleArrayOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleArrayOptions_ReturnEnabled")]
        public System.Boolean DoubleArrayOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter DoubleOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleOptions_ReturnEnabled")]
        public System.Boolean DoubleOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter IntArrayOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntArrayOptions_ReturnEnabled")]
        public System.Boolean IntArrayOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter IntOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntOptions_ReturnEnabled")]
        public System.Boolean IntOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter LatLonOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LatLonOptions_ReturnEnabled")]
        public System.Boolean LatLonOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter LiteralArrayOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralArrayOptions_ReturnEnabled")]
        public System.Boolean LiteralArrayOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter LiteralOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralOptions_ReturnEnabled")]
        public System.Boolean LiteralOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter TextArrayOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextArrayOptions_ReturnEnabled")]
        public System.Boolean TextArrayOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter TextOptions_ReturnEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field can be returned in the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextOptions_ReturnEnabled")]
        public System.Boolean TextOptions_ReturnEnabled { get; set; }
        #endregion
        
        #region Parameter DateArrayOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateArrayOptions_SearchEnabled")]
        public System.Boolean DateArrayOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter DateOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateOptions_SearchEnabled")]
        public System.Boolean DateOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter DoubleArrayOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleArrayOptions_SearchEnabled")]
        public System.Boolean DoubleArrayOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter DoubleOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleOptions_SearchEnabled")]
        public System.Boolean DoubleOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter IntArrayOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntArrayOptions_SearchEnabled")]
        public System.Boolean IntArrayOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter IntOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntOptions_SearchEnabled")]
        public System.Boolean IntOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter LatLonOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LatLonOptions_SearchEnabled")]
        public System.Boolean LatLonOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter LiteralArrayOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralArrayOptions_SearchEnabled")]
        public System.Boolean LiteralArrayOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter LiteralOptions_SearchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the contents of the field are searchable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralOptions_SearchEnabled")]
        public System.Boolean LiteralOptions_SearchEnabled { get; set; }
        #endregion
        
        #region Parameter DateOptions_SortEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the field can be used to sort the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateOptions_SortEnabled")]
        public System.Boolean DateOptions_SortEnabled { get; set; }
        #endregion
        
        #region Parameter DoubleOptions_SortEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the field can be used to sort the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleOptions_SortEnabled")]
        public System.Boolean DoubleOptions_SortEnabled { get; set; }
        #endregion
        
        #region Parameter IntOptions_SortEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the field can be used to sort the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntOptions_SortEnabled")]
        public System.Boolean IntOptions_SortEnabled { get; set; }
        #endregion
        
        #region Parameter LatLonOptions_SortEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the field can be used to sort the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LatLonOptions_SortEnabled")]
        public System.Boolean LatLonOptions_SortEnabled { get; set; }
        #endregion
        
        #region Parameter LiteralOptions_SortEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the field can be used to sort the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralOptions_SortEnabled")]
        public System.Boolean LiteralOptions_SortEnabled { get; set; }
        #endregion
        
        #region Parameter TextOptions_SortEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the field can be used to sort the search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextOptions_SortEnabled")]
        public System.Boolean TextOptions_SortEnabled { get; set; }
        #endregion
        
        #region Parameter DateOptions_SourceField
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateOptions_SourceField")]
        public System.String DateOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter DoubleOptions_SourceField
        /// <summary>
        /// <para>
        /// <para>The name of the source field to map to the field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleOptions_SourceField")]
        public System.String DoubleOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter IntOptions_SourceField
        /// <summary>
        /// <para>
        /// <para>The name of the source field to map to the field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntOptions_SourceField")]
        public System.String IntOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter LatLonOptions_SourceField
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LatLonOptions_SourceField")]
        public System.String LatLonOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter LiteralOptions_SourceField
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralOptions_SourceField")]
        public System.String LiteralOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter TextOptions_SourceField
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextOptions_SourceField")]
        public System.String TextOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter DateArrayOptions_SourceField
        /// <summary>
        /// <para>
        /// <para>A list of source fields to map to the field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DateArrayOptions_SourceFields")]
        public System.String DateArrayOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter DoubleArrayOptions_SourceField
        /// <summary>
        /// <para>
        /// <para>A list of source fields to map to the field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_DoubleArrayOptions_SourceFields")]
        public System.String DoubleArrayOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter IntArrayOptions_SourceField
        /// <summary>
        /// <para>
        /// <para>A list of source fields to map to the field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_IntArrayOptions_SourceFields")]
        public System.String IntArrayOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter LiteralArrayOptions_SourceField
        /// <summary>
        /// <para>
        /// <para>A list of source fields to map to the field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_LiteralArrayOptions_SourceFields")]
        public System.String LiteralArrayOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter TextArrayOptions_SourceField
        /// <summary>
        /// <para>
        /// <para>A list of source fields to map to the field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IndexField_TextArrayOptions_SourceFields")]
        public System.String TextArrayOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CSIndexField (DefineIndexField)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DomainName = this.DomainName;
            context.IndexField_DateArrayOptions_DefaultValue = this.DateArrayOptions_DefaultValue;
            if (ParameterWasBound("DateArrayOptions_FacetEnabled"))
                context.IndexField_DateArrayOptions_FacetEnabled = this.DateArrayOptions_FacetEnabled;
            if (ParameterWasBound("DateArrayOptions_ReturnEnabled"))
                context.IndexField_DateArrayOptions_ReturnEnabled = this.DateArrayOptions_ReturnEnabled;
            if (ParameterWasBound("DateArrayOptions_SearchEnabled"))
                context.IndexField_DateArrayOptions_SearchEnabled = this.DateArrayOptions_SearchEnabled;
            context.IndexField_DateArrayOptions_SourceFields = this.DateArrayOptions_SourceField;
            context.IndexField_DateOptions_DefaultValue = this.DateOptions_DefaultValue;
            if (ParameterWasBound("DateOptions_FacetEnabled"))
                context.IndexField_DateOptions_FacetEnabled = this.DateOptions_FacetEnabled;
            if (ParameterWasBound("DateOptions_ReturnEnabled"))
                context.IndexField_DateOptions_ReturnEnabled = this.DateOptions_ReturnEnabled;
            if (ParameterWasBound("DateOptions_SearchEnabled"))
                context.IndexField_DateOptions_SearchEnabled = this.DateOptions_SearchEnabled;
            if (ParameterWasBound("DateOptions_SortEnabled"))
                context.IndexField_DateOptions_SortEnabled = this.DateOptions_SortEnabled;
            context.IndexField_DateOptions_SourceField = this.DateOptions_SourceField;
            if (ParameterWasBound("DoubleArrayOptions_DefaultValue"))
                context.IndexField_DoubleArrayOptions_DefaultValue = this.DoubleArrayOptions_DefaultValue;
            if (ParameterWasBound("DoubleArrayOptions_FacetEnabled"))
                context.IndexField_DoubleArrayOptions_FacetEnabled = this.DoubleArrayOptions_FacetEnabled;
            if (ParameterWasBound("DoubleArrayOptions_ReturnEnabled"))
                context.IndexField_DoubleArrayOptions_ReturnEnabled = this.DoubleArrayOptions_ReturnEnabled;
            if (ParameterWasBound("DoubleArrayOptions_SearchEnabled"))
                context.IndexField_DoubleArrayOptions_SearchEnabled = this.DoubleArrayOptions_SearchEnabled;
            context.IndexField_DoubleArrayOptions_SourceFields = this.DoubleArrayOptions_SourceField;
            if (ParameterWasBound("DoubleOptions_DefaultValue"))
                context.IndexField_DoubleOptions_DefaultValue = this.DoubleOptions_DefaultValue;
            if (ParameterWasBound("DoubleOptions_FacetEnabled"))
                context.IndexField_DoubleOptions_FacetEnabled = this.DoubleOptions_FacetEnabled;
            if (ParameterWasBound("DoubleOptions_ReturnEnabled"))
                context.IndexField_DoubleOptions_ReturnEnabled = this.DoubleOptions_ReturnEnabled;
            if (ParameterWasBound("DoubleOptions_SearchEnabled"))
                context.IndexField_DoubleOptions_SearchEnabled = this.DoubleOptions_SearchEnabled;
            if (ParameterWasBound("DoubleOptions_SortEnabled"))
                context.IndexField_DoubleOptions_SortEnabled = this.DoubleOptions_SortEnabled;
            context.IndexField_DoubleOptions_SourceField = this.DoubleOptions_SourceField;
            context.IndexField_IndexFieldName = this.IndexField_IndexFieldName;
            context.IndexField_IndexFieldType = this.IndexField_IndexFieldType;
            if (ParameterWasBound("IntArrayOptions_DefaultValue"))
                context.IndexField_IntArrayOptions_DefaultValue = this.IntArrayOptions_DefaultValue;
            if (ParameterWasBound("IntArrayOptions_FacetEnabled"))
                context.IndexField_IntArrayOptions_FacetEnabled = this.IntArrayOptions_FacetEnabled;
            if (ParameterWasBound("IntArrayOptions_ReturnEnabled"))
                context.IndexField_IntArrayOptions_ReturnEnabled = this.IntArrayOptions_ReturnEnabled;
            if (ParameterWasBound("IntArrayOptions_SearchEnabled"))
                context.IndexField_IntArrayOptions_SearchEnabled = this.IntArrayOptions_SearchEnabled;
            context.IndexField_IntArrayOptions_SourceFields = this.IntArrayOptions_SourceField;
            if (ParameterWasBound("IntOptions_DefaultValue"))
                context.IndexField_IntOptions_DefaultValue = this.IntOptions_DefaultValue;
            if (ParameterWasBound("IntOptions_FacetEnabled"))
                context.IndexField_IntOptions_FacetEnabled = this.IntOptions_FacetEnabled;
            if (ParameterWasBound("IntOptions_ReturnEnabled"))
                context.IndexField_IntOptions_ReturnEnabled = this.IntOptions_ReturnEnabled;
            if (ParameterWasBound("IntOptions_SearchEnabled"))
                context.IndexField_IntOptions_SearchEnabled = this.IntOptions_SearchEnabled;
            if (ParameterWasBound("IntOptions_SortEnabled"))
                context.IndexField_IntOptions_SortEnabled = this.IntOptions_SortEnabled;
            context.IndexField_IntOptions_SourceField = this.IntOptions_SourceField;
            context.IndexField_LatLonOptions_DefaultValue = this.LatLonOptions_DefaultValue;
            if (ParameterWasBound("LatLonOptions_FacetEnabled"))
                context.IndexField_LatLonOptions_FacetEnabled = this.LatLonOptions_FacetEnabled;
            if (ParameterWasBound("LatLonOptions_ReturnEnabled"))
                context.IndexField_LatLonOptions_ReturnEnabled = this.LatLonOptions_ReturnEnabled;
            if (ParameterWasBound("LatLonOptions_SearchEnabled"))
                context.IndexField_LatLonOptions_SearchEnabled = this.LatLonOptions_SearchEnabled;
            if (ParameterWasBound("LatLonOptions_SortEnabled"))
                context.IndexField_LatLonOptions_SortEnabled = this.LatLonOptions_SortEnabled;
            context.IndexField_LatLonOptions_SourceField = this.LatLonOptions_SourceField;
            context.IndexField_LiteralArrayOptions_DefaultValue = this.LiteralArrayOptions_DefaultValue;
            if (ParameterWasBound("LiteralArrayOptions_FacetEnabled"))
                context.IndexField_LiteralArrayOptions_FacetEnabled = this.LiteralArrayOptions_FacetEnabled;
            if (ParameterWasBound("LiteralArrayOptions_ReturnEnabled"))
                context.IndexField_LiteralArrayOptions_ReturnEnabled = this.LiteralArrayOptions_ReturnEnabled;
            if (ParameterWasBound("LiteralArrayOptions_SearchEnabled"))
                context.IndexField_LiteralArrayOptions_SearchEnabled = this.LiteralArrayOptions_SearchEnabled;
            context.IndexField_LiteralArrayOptions_SourceFields = this.LiteralArrayOptions_SourceField;
            context.IndexField_LiteralOptions_DefaultValue = this.LiteralOptions_DefaultValue;
            if (ParameterWasBound("LiteralOptions_FacetEnabled"))
                context.IndexField_LiteralOptions_FacetEnabled = this.LiteralOptions_FacetEnabled;
            if (ParameterWasBound("LiteralOptions_ReturnEnabled"))
                context.IndexField_LiteralOptions_ReturnEnabled = this.LiteralOptions_ReturnEnabled;
            if (ParameterWasBound("LiteralOptions_SearchEnabled"))
                context.IndexField_LiteralOptions_SearchEnabled = this.LiteralOptions_SearchEnabled;
            if (ParameterWasBound("LiteralOptions_SortEnabled"))
                context.IndexField_LiteralOptions_SortEnabled = this.LiteralOptions_SortEnabled;
            context.IndexField_LiteralOptions_SourceField = this.LiteralOptions_SourceField;
            context.IndexField_TextArrayOptions_AnalysisScheme = this.TextArrayOptions_AnalysisScheme;
            context.IndexField_TextArrayOptions_DefaultValue = this.TextArrayOptions_DefaultValue;
            if (ParameterWasBound("TextArrayOptions_HighlightEnabled"))
                context.IndexField_TextArrayOptions_HighlightEnabled = this.TextArrayOptions_HighlightEnabled;
            if (ParameterWasBound("TextArrayOptions_ReturnEnabled"))
                context.IndexField_TextArrayOptions_ReturnEnabled = this.TextArrayOptions_ReturnEnabled;
            context.IndexField_TextArrayOptions_SourceFields = this.TextArrayOptions_SourceField;
            context.IndexField_TextOptions_AnalysisScheme = this.TextOptions_AnalysisScheme;
            context.IndexField_TextOptions_DefaultValue = this.TextOptions_DefaultValue;
            if (ParameterWasBound("TextOptions_HighlightEnabled"))
                context.IndexField_TextOptions_HighlightEnabled = this.TextOptions_HighlightEnabled;
            if (ParameterWasBound("TextOptions_ReturnEnabled"))
                context.IndexField_TextOptions_ReturnEnabled = this.TextOptions_ReturnEnabled;
            if (ParameterWasBound("TextOptions_SortEnabled"))
                context.IndexField_TextOptions_SortEnabled = this.TextOptions_SortEnabled;
            context.IndexField_TextOptions_SourceField = this.TextOptions_SourceField;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudSearch.Model.DefineIndexFieldRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate IndexField
            bool requestIndexFieldIsNull = true;
            request.IndexField = new Amazon.CloudSearch.Model.IndexField();
            System.String requestIndexField_indexField_IndexFieldName = null;
            if (cmdletContext.IndexField_IndexFieldName != null)
            {
                requestIndexField_indexField_IndexFieldName = cmdletContext.IndexField_IndexFieldName;
            }
            if (requestIndexField_indexField_IndexFieldName != null)
            {
                request.IndexField.IndexFieldName = requestIndexField_indexField_IndexFieldName;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.IndexFieldType requestIndexField_indexField_IndexFieldType = null;
            if (cmdletContext.IndexField_IndexFieldType != null)
            {
                requestIndexField_indexField_IndexFieldType = cmdletContext.IndexField_IndexFieldType;
            }
            if (requestIndexField_indexField_IndexFieldType != null)
            {
                request.IndexField.IndexFieldType = requestIndexField_indexField_IndexFieldType;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.DateArrayOptions requestIndexField_indexField_DateArrayOptions = null;
            
             // populate DateArrayOptions
            bool requestIndexField_indexField_DateArrayOptionsIsNull = true;
            requestIndexField_indexField_DateArrayOptions = new Amazon.CloudSearch.Model.DateArrayOptions();
            System.String requestIndexField_indexField_DateArrayOptions_dateArrayOptions_DefaultValue = null;
            if (cmdletContext.IndexField_DateArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_DateArrayOptions_dateArrayOptions_DefaultValue = cmdletContext.IndexField_DateArrayOptions_DefaultValue;
            }
            if (requestIndexField_indexField_DateArrayOptions_dateArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_DateArrayOptions.DefaultValue = requestIndexField_indexField_DateArrayOptions_dateArrayOptions_DefaultValue;
                requestIndexField_indexField_DateArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DateArrayOptions_dateArrayOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_DateArrayOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_DateArrayOptions_dateArrayOptions_FacetEnabled = cmdletContext.IndexField_DateArrayOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_DateArrayOptions_dateArrayOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_DateArrayOptions.FacetEnabled = requestIndexField_indexField_DateArrayOptions_dateArrayOptions_FacetEnabled.Value;
                requestIndexField_indexField_DateArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DateArrayOptions_dateArrayOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_DateArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_DateArrayOptions_dateArrayOptions_ReturnEnabled = cmdletContext.IndexField_DateArrayOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_DateArrayOptions_dateArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_DateArrayOptions.ReturnEnabled = requestIndexField_indexField_DateArrayOptions_dateArrayOptions_ReturnEnabled.Value;
                requestIndexField_indexField_DateArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DateArrayOptions_dateArrayOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_DateArrayOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_DateArrayOptions_dateArrayOptions_SearchEnabled = cmdletContext.IndexField_DateArrayOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_DateArrayOptions_dateArrayOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_DateArrayOptions.SearchEnabled = requestIndexField_indexField_DateArrayOptions_dateArrayOptions_SearchEnabled.Value;
                requestIndexField_indexField_DateArrayOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_DateArrayOptions_dateArrayOptions_SourceField = null;
            if (cmdletContext.IndexField_DateArrayOptions_SourceFields != null)
            {
                requestIndexField_indexField_DateArrayOptions_dateArrayOptions_SourceField = cmdletContext.IndexField_DateArrayOptions_SourceFields;
            }
            if (requestIndexField_indexField_DateArrayOptions_dateArrayOptions_SourceField != null)
            {
                requestIndexField_indexField_DateArrayOptions.SourceFields = requestIndexField_indexField_DateArrayOptions_dateArrayOptions_SourceField;
                requestIndexField_indexField_DateArrayOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_DateArrayOptions should be set to null
            if (requestIndexField_indexField_DateArrayOptionsIsNull)
            {
                requestIndexField_indexField_DateArrayOptions = null;
            }
            if (requestIndexField_indexField_DateArrayOptions != null)
            {
                request.IndexField.DateArrayOptions = requestIndexField_indexField_DateArrayOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.DoubleArrayOptions requestIndexField_indexField_DoubleArrayOptions = null;
            
             // populate DoubleArrayOptions
            bool requestIndexField_indexField_DoubleArrayOptionsIsNull = true;
            requestIndexField_indexField_DoubleArrayOptions = new Amazon.CloudSearch.Model.DoubleArrayOptions();
            System.Double? requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_DefaultValue = null;
            if (cmdletContext.IndexField_DoubleArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_DefaultValue = cmdletContext.IndexField_DoubleArrayOptions_DefaultValue.Value;
            }
            if (requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_DoubleArrayOptions.DefaultValue = requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_DefaultValue.Value;
                requestIndexField_indexField_DoubleArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_DoubleArrayOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_FacetEnabled = cmdletContext.IndexField_DoubleArrayOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_DoubleArrayOptions.FacetEnabled = requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_FacetEnabled.Value;
                requestIndexField_indexField_DoubleArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_DoubleArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_ReturnEnabled = cmdletContext.IndexField_DoubleArrayOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_DoubleArrayOptions.ReturnEnabled = requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_ReturnEnabled.Value;
                requestIndexField_indexField_DoubleArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_DoubleArrayOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_SearchEnabled = cmdletContext.IndexField_DoubleArrayOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_DoubleArrayOptions.SearchEnabled = requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_SearchEnabled.Value;
                requestIndexField_indexField_DoubleArrayOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_SourceField = null;
            if (cmdletContext.IndexField_DoubleArrayOptions_SourceFields != null)
            {
                requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_SourceField = cmdletContext.IndexField_DoubleArrayOptions_SourceFields;
            }
            if (requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_SourceField != null)
            {
                requestIndexField_indexField_DoubleArrayOptions.SourceFields = requestIndexField_indexField_DoubleArrayOptions_doubleArrayOptions_SourceField;
                requestIndexField_indexField_DoubleArrayOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_DoubleArrayOptions should be set to null
            if (requestIndexField_indexField_DoubleArrayOptionsIsNull)
            {
                requestIndexField_indexField_DoubleArrayOptions = null;
            }
            if (requestIndexField_indexField_DoubleArrayOptions != null)
            {
                request.IndexField.DoubleArrayOptions = requestIndexField_indexField_DoubleArrayOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.IntArrayOptions requestIndexField_indexField_IntArrayOptions = null;
            
             // populate IntArrayOptions
            bool requestIndexField_indexField_IntArrayOptionsIsNull = true;
            requestIndexField_indexField_IntArrayOptions = new Amazon.CloudSearch.Model.IntArrayOptions();
            System.Int64? requestIndexField_indexField_IntArrayOptions_intArrayOptions_DefaultValue = null;
            if (cmdletContext.IndexField_IntArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_IntArrayOptions_intArrayOptions_DefaultValue = cmdletContext.IndexField_IntArrayOptions_DefaultValue.Value;
            }
            if (requestIndexField_indexField_IntArrayOptions_intArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_IntArrayOptions.DefaultValue = requestIndexField_indexField_IntArrayOptions_intArrayOptions_DefaultValue.Value;
                requestIndexField_indexField_IntArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_IntArrayOptions_intArrayOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_IntArrayOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_IntArrayOptions_intArrayOptions_FacetEnabled = cmdletContext.IndexField_IntArrayOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_IntArrayOptions_intArrayOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_IntArrayOptions.FacetEnabled = requestIndexField_indexField_IntArrayOptions_intArrayOptions_FacetEnabled.Value;
                requestIndexField_indexField_IntArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_IntArrayOptions_intArrayOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_IntArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_IntArrayOptions_intArrayOptions_ReturnEnabled = cmdletContext.IndexField_IntArrayOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_IntArrayOptions_intArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_IntArrayOptions.ReturnEnabled = requestIndexField_indexField_IntArrayOptions_intArrayOptions_ReturnEnabled.Value;
                requestIndexField_indexField_IntArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_IntArrayOptions_intArrayOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_IntArrayOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_IntArrayOptions_intArrayOptions_SearchEnabled = cmdletContext.IndexField_IntArrayOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_IntArrayOptions_intArrayOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_IntArrayOptions.SearchEnabled = requestIndexField_indexField_IntArrayOptions_intArrayOptions_SearchEnabled.Value;
                requestIndexField_indexField_IntArrayOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_IntArrayOptions_intArrayOptions_SourceField = null;
            if (cmdletContext.IndexField_IntArrayOptions_SourceFields != null)
            {
                requestIndexField_indexField_IntArrayOptions_intArrayOptions_SourceField = cmdletContext.IndexField_IntArrayOptions_SourceFields;
            }
            if (requestIndexField_indexField_IntArrayOptions_intArrayOptions_SourceField != null)
            {
                requestIndexField_indexField_IntArrayOptions.SourceFields = requestIndexField_indexField_IntArrayOptions_intArrayOptions_SourceField;
                requestIndexField_indexField_IntArrayOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_IntArrayOptions should be set to null
            if (requestIndexField_indexField_IntArrayOptionsIsNull)
            {
                requestIndexField_indexField_IntArrayOptions = null;
            }
            if (requestIndexField_indexField_IntArrayOptions != null)
            {
                request.IndexField.IntArrayOptions = requestIndexField_indexField_IntArrayOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.LiteralArrayOptions requestIndexField_indexField_LiteralArrayOptions = null;
            
             // populate LiteralArrayOptions
            bool requestIndexField_indexField_LiteralArrayOptionsIsNull = true;
            requestIndexField_indexField_LiteralArrayOptions = new Amazon.CloudSearch.Model.LiteralArrayOptions();
            System.String requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_DefaultValue = null;
            if (cmdletContext.IndexField_LiteralArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_DefaultValue = cmdletContext.IndexField_LiteralArrayOptions_DefaultValue;
            }
            if (requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_LiteralArrayOptions.DefaultValue = requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_DefaultValue;
                requestIndexField_indexField_LiteralArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_LiteralArrayOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_FacetEnabled = cmdletContext.IndexField_LiteralArrayOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_LiteralArrayOptions.FacetEnabled = requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_FacetEnabled.Value;
                requestIndexField_indexField_LiteralArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_LiteralArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_ReturnEnabled = cmdletContext.IndexField_LiteralArrayOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_LiteralArrayOptions.ReturnEnabled = requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_ReturnEnabled.Value;
                requestIndexField_indexField_LiteralArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_LiteralArrayOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_SearchEnabled = cmdletContext.IndexField_LiteralArrayOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_LiteralArrayOptions.SearchEnabled = requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_SearchEnabled.Value;
                requestIndexField_indexField_LiteralArrayOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_SourceField = null;
            if (cmdletContext.IndexField_LiteralArrayOptions_SourceFields != null)
            {
                requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_SourceField = cmdletContext.IndexField_LiteralArrayOptions_SourceFields;
            }
            if (requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_SourceField != null)
            {
                requestIndexField_indexField_LiteralArrayOptions.SourceFields = requestIndexField_indexField_LiteralArrayOptions_literalArrayOptions_SourceField;
                requestIndexField_indexField_LiteralArrayOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_LiteralArrayOptions should be set to null
            if (requestIndexField_indexField_LiteralArrayOptionsIsNull)
            {
                requestIndexField_indexField_LiteralArrayOptions = null;
            }
            if (requestIndexField_indexField_LiteralArrayOptions != null)
            {
                request.IndexField.LiteralArrayOptions = requestIndexField_indexField_LiteralArrayOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.TextArrayOptions requestIndexField_indexField_TextArrayOptions = null;
            
             // populate TextArrayOptions
            bool requestIndexField_indexField_TextArrayOptionsIsNull = true;
            requestIndexField_indexField_TextArrayOptions = new Amazon.CloudSearch.Model.TextArrayOptions();
            System.String requestIndexField_indexField_TextArrayOptions_textArrayOptions_AnalysisScheme = null;
            if (cmdletContext.IndexField_TextArrayOptions_AnalysisScheme != null)
            {
                requestIndexField_indexField_TextArrayOptions_textArrayOptions_AnalysisScheme = cmdletContext.IndexField_TextArrayOptions_AnalysisScheme;
            }
            if (requestIndexField_indexField_TextArrayOptions_textArrayOptions_AnalysisScheme != null)
            {
                requestIndexField_indexField_TextArrayOptions.AnalysisScheme = requestIndexField_indexField_TextArrayOptions_textArrayOptions_AnalysisScheme;
                requestIndexField_indexField_TextArrayOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_TextArrayOptions_textArrayOptions_DefaultValue = null;
            if (cmdletContext.IndexField_TextArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_TextArrayOptions_textArrayOptions_DefaultValue = cmdletContext.IndexField_TextArrayOptions_DefaultValue;
            }
            if (requestIndexField_indexField_TextArrayOptions_textArrayOptions_DefaultValue != null)
            {
                requestIndexField_indexField_TextArrayOptions.DefaultValue = requestIndexField_indexField_TextArrayOptions_textArrayOptions_DefaultValue;
                requestIndexField_indexField_TextArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_TextArrayOptions_textArrayOptions_HighlightEnabled = null;
            if (cmdletContext.IndexField_TextArrayOptions_HighlightEnabled != null)
            {
                requestIndexField_indexField_TextArrayOptions_textArrayOptions_HighlightEnabled = cmdletContext.IndexField_TextArrayOptions_HighlightEnabled.Value;
            }
            if (requestIndexField_indexField_TextArrayOptions_textArrayOptions_HighlightEnabled != null)
            {
                requestIndexField_indexField_TextArrayOptions.HighlightEnabled = requestIndexField_indexField_TextArrayOptions_textArrayOptions_HighlightEnabled.Value;
                requestIndexField_indexField_TextArrayOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_TextArrayOptions_textArrayOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_TextArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_TextArrayOptions_textArrayOptions_ReturnEnabled = cmdletContext.IndexField_TextArrayOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_TextArrayOptions_textArrayOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_TextArrayOptions.ReturnEnabled = requestIndexField_indexField_TextArrayOptions_textArrayOptions_ReturnEnabled.Value;
                requestIndexField_indexField_TextArrayOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_TextArrayOptions_textArrayOptions_SourceField = null;
            if (cmdletContext.IndexField_TextArrayOptions_SourceFields != null)
            {
                requestIndexField_indexField_TextArrayOptions_textArrayOptions_SourceField = cmdletContext.IndexField_TextArrayOptions_SourceFields;
            }
            if (requestIndexField_indexField_TextArrayOptions_textArrayOptions_SourceField != null)
            {
                requestIndexField_indexField_TextArrayOptions.SourceFields = requestIndexField_indexField_TextArrayOptions_textArrayOptions_SourceField;
                requestIndexField_indexField_TextArrayOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_TextArrayOptions should be set to null
            if (requestIndexField_indexField_TextArrayOptionsIsNull)
            {
                requestIndexField_indexField_TextArrayOptions = null;
            }
            if (requestIndexField_indexField_TextArrayOptions != null)
            {
                request.IndexField.TextArrayOptions = requestIndexField_indexField_TextArrayOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.DateOptions requestIndexField_indexField_DateOptions = null;
            
             // populate DateOptions
            bool requestIndexField_indexField_DateOptionsIsNull = true;
            requestIndexField_indexField_DateOptions = new Amazon.CloudSearch.Model.DateOptions();
            System.String requestIndexField_indexField_DateOptions_dateOptions_DefaultValue = null;
            if (cmdletContext.IndexField_DateOptions_DefaultValue != null)
            {
                requestIndexField_indexField_DateOptions_dateOptions_DefaultValue = cmdletContext.IndexField_DateOptions_DefaultValue;
            }
            if (requestIndexField_indexField_DateOptions_dateOptions_DefaultValue != null)
            {
                requestIndexField_indexField_DateOptions.DefaultValue = requestIndexField_indexField_DateOptions_dateOptions_DefaultValue;
                requestIndexField_indexField_DateOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DateOptions_dateOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_DateOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_DateOptions_dateOptions_FacetEnabled = cmdletContext.IndexField_DateOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_DateOptions_dateOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_DateOptions.FacetEnabled = requestIndexField_indexField_DateOptions_dateOptions_FacetEnabled.Value;
                requestIndexField_indexField_DateOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DateOptions_dateOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_DateOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_DateOptions_dateOptions_ReturnEnabled = cmdletContext.IndexField_DateOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_DateOptions_dateOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_DateOptions.ReturnEnabled = requestIndexField_indexField_DateOptions_dateOptions_ReturnEnabled.Value;
                requestIndexField_indexField_DateOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DateOptions_dateOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_DateOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_DateOptions_dateOptions_SearchEnabled = cmdletContext.IndexField_DateOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_DateOptions_dateOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_DateOptions.SearchEnabled = requestIndexField_indexField_DateOptions_dateOptions_SearchEnabled.Value;
                requestIndexField_indexField_DateOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DateOptions_dateOptions_SortEnabled = null;
            if (cmdletContext.IndexField_DateOptions_SortEnabled != null)
            {
                requestIndexField_indexField_DateOptions_dateOptions_SortEnabled = cmdletContext.IndexField_DateOptions_SortEnabled.Value;
            }
            if (requestIndexField_indexField_DateOptions_dateOptions_SortEnabled != null)
            {
                requestIndexField_indexField_DateOptions.SortEnabled = requestIndexField_indexField_DateOptions_dateOptions_SortEnabled.Value;
                requestIndexField_indexField_DateOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_DateOptions_dateOptions_SourceField = null;
            if (cmdletContext.IndexField_DateOptions_SourceField != null)
            {
                requestIndexField_indexField_DateOptions_dateOptions_SourceField = cmdletContext.IndexField_DateOptions_SourceField;
            }
            if (requestIndexField_indexField_DateOptions_dateOptions_SourceField != null)
            {
                requestIndexField_indexField_DateOptions.SourceField = requestIndexField_indexField_DateOptions_dateOptions_SourceField;
                requestIndexField_indexField_DateOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_DateOptions should be set to null
            if (requestIndexField_indexField_DateOptionsIsNull)
            {
                requestIndexField_indexField_DateOptions = null;
            }
            if (requestIndexField_indexField_DateOptions != null)
            {
                request.IndexField.DateOptions = requestIndexField_indexField_DateOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.DoubleOptions requestIndexField_indexField_DoubleOptions = null;
            
             // populate DoubleOptions
            bool requestIndexField_indexField_DoubleOptionsIsNull = true;
            requestIndexField_indexField_DoubleOptions = new Amazon.CloudSearch.Model.DoubleOptions();
            System.Double? requestIndexField_indexField_DoubleOptions_doubleOptions_DefaultValue = null;
            if (cmdletContext.IndexField_DoubleOptions_DefaultValue != null)
            {
                requestIndexField_indexField_DoubleOptions_doubleOptions_DefaultValue = cmdletContext.IndexField_DoubleOptions_DefaultValue.Value;
            }
            if (requestIndexField_indexField_DoubleOptions_doubleOptions_DefaultValue != null)
            {
                requestIndexField_indexField_DoubleOptions.DefaultValue = requestIndexField_indexField_DoubleOptions_doubleOptions_DefaultValue.Value;
                requestIndexField_indexField_DoubleOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DoubleOptions_doubleOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_DoubleOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_DoubleOptions_doubleOptions_FacetEnabled = cmdletContext.IndexField_DoubleOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_DoubleOptions_doubleOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_DoubleOptions.FacetEnabled = requestIndexField_indexField_DoubleOptions_doubleOptions_FacetEnabled.Value;
                requestIndexField_indexField_DoubleOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DoubleOptions_doubleOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_DoubleOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_DoubleOptions_doubleOptions_ReturnEnabled = cmdletContext.IndexField_DoubleOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_DoubleOptions_doubleOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_DoubleOptions.ReturnEnabled = requestIndexField_indexField_DoubleOptions_doubleOptions_ReturnEnabled.Value;
                requestIndexField_indexField_DoubleOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DoubleOptions_doubleOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_DoubleOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_DoubleOptions_doubleOptions_SearchEnabled = cmdletContext.IndexField_DoubleOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_DoubleOptions_doubleOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_DoubleOptions.SearchEnabled = requestIndexField_indexField_DoubleOptions_doubleOptions_SearchEnabled.Value;
                requestIndexField_indexField_DoubleOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_DoubleOptions_doubleOptions_SortEnabled = null;
            if (cmdletContext.IndexField_DoubleOptions_SortEnabled != null)
            {
                requestIndexField_indexField_DoubleOptions_doubleOptions_SortEnabled = cmdletContext.IndexField_DoubleOptions_SortEnabled.Value;
            }
            if (requestIndexField_indexField_DoubleOptions_doubleOptions_SortEnabled != null)
            {
                requestIndexField_indexField_DoubleOptions.SortEnabled = requestIndexField_indexField_DoubleOptions_doubleOptions_SortEnabled.Value;
                requestIndexField_indexField_DoubleOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_DoubleOptions_doubleOptions_SourceField = null;
            if (cmdletContext.IndexField_DoubleOptions_SourceField != null)
            {
                requestIndexField_indexField_DoubleOptions_doubleOptions_SourceField = cmdletContext.IndexField_DoubleOptions_SourceField;
            }
            if (requestIndexField_indexField_DoubleOptions_doubleOptions_SourceField != null)
            {
                requestIndexField_indexField_DoubleOptions.SourceField = requestIndexField_indexField_DoubleOptions_doubleOptions_SourceField;
                requestIndexField_indexField_DoubleOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_DoubleOptions should be set to null
            if (requestIndexField_indexField_DoubleOptionsIsNull)
            {
                requestIndexField_indexField_DoubleOptions = null;
            }
            if (requestIndexField_indexField_DoubleOptions != null)
            {
                request.IndexField.DoubleOptions = requestIndexField_indexField_DoubleOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.IntOptions requestIndexField_indexField_IntOptions = null;
            
             // populate IntOptions
            bool requestIndexField_indexField_IntOptionsIsNull = true;
            requestIndexField_indexField_IntOptions = new Amazon.CloudSearch.Model.IntOptions();
            System.Int64? requestIndexField_indexField_IntOptions_intOptions_DefaultValue = null;
            if (cmdletContext.IndexField_IntOptions_DefaultValue != null)
            {
                requestIndexField_indexField_IntOptions_intOptions_DefaultValue = cmdletContext.IndexField_IntOptions_DefaultValue.Value;
            }
            if (requestIndexField_indexField_IntOptions_intOptions_DefaultValue != null)
            {
                requestIndexField_indexField_IntOptions.DefaultValue = requestIndexField_indexField_IntOptions_intOptions_DefaultValue.Value;
                requestIndexField_indexField_IntOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_IntOptions_intOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_IntOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_IntOptions_intOptions_FacetEnabled = cmdletContext.IndexField_IntOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_IntOptions_intOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_IntOptions.FacetEnabled = requestIndexField_indexField_IntOptions_intOptions_FacetEnabled.Value;
                requestIndexField_indexField_IntOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_IntOptions_intOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_IntOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_IntOptions_intOptions_ReturnEnabled = cmdletContext.IndexField_IntOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_IntOptions_intOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_IntOptions.ReturnEnabled = requestIndexField_indexField_IntOptions_intOptions_ReturnEnabled.Value;
                requestIndexField_indexField_IntOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_IntOptions_intOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_IntOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_IntOptions_intOptions_SearchEnabled = cmdletContext.IndexField_IntOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_IntOptions_intOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_IntOptions.SearchEnabled = requestIndexField_indexField_IntOptions_intOptions_SearchEnabled.Value;
                requestIndexField_indexField_IntOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_IntOptions_intOptions_SortEnabled = null;
            if (cmdletContext.IndexField_IntOptions_SortEnabled != null)
            {
                requestIndexField_indexField_IntOptions_intOptions_SortEnabled = cmdletContext.IndexField_IntOptions_SortEnabled.Value;
            }
            if (requestIndexField_indexField_IntOptions_intOptions_SortEnabled != null)
            {
                requestIndexField_indexField_IntOptions.SortEnabled = requestIndexField_indexField_IntOptions_intOptions_SortEnabled.Value;
                requestIndexField_indexField_IntOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_IntOptions_intOptions_SourceField = null;
            if (cmdletContext.IndexField_IntOptions_SourceField != null)
            {
                requestIndexField_indexField_IntOptions_intOptions_SourceField = cmdletContext.IndexField_IntOptions_SourceField;
            }
            if (requestIndexField_indexField_IntOptions_intOptions_SourceField != null)
            {
                requestIndexField_indexField_IntOptions.SourceField = requestIndexField_indexField_IntOptions_intOptions_SourceField;
                requestIndexField_indexField_IntOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_IntOptions should be set to null
            if (requestIndexField_indexField_IntOptionsIsNull)
            {
                requestIndexField_indexField_IntOptions = null;
            }
            if (requestIndexField_indexField_IntOptions != null)
            {
                request.IndexField.IntOptions = requestIndexField_indexField_IntOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.LatLonOptions requestIndexField_indexField_LatLonOptions = null;
            
             // populate LatLonOptions
            bool requestIndexField_indexField_LatLonOptionsIsNull = true;
            requestIndexField_indexField_LatLonOptions = new Amazon.CloudSearch.Model.LatLonOptions();
            System.String requestIndexField_indexField_LatLonOptions_latLonOptions_DefaultValue = null;
            if (cmdletContext.IndexField_LatLonOptions_DefaultValue != null)
            {
                requestIndexField_indexField_LatLonOptions_latLonOptions_DefaultValue = cmdletContext.IndexField_LatLonOptions_DefaultValue;
            }
            if (requestIndexField_indexField_LatLonOptions_latLonOptions_DefaultValue != null)
            {
                requestIndexField_indexField_LatLonOptions.DefaultValue = requestIndexField_indexField_LatLonOptions_latLonOptions_DefaultValue;
                requestIndexField_indexField_LatLonOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LatLonOptions_latLonOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_LatLonOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_LatLonOptions_latLonOptions_FacetEnabled = cmdletContext.IndexField_LatLonOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_LatLonOptions_latLonOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_LatLonOptions.FacetEnabled = requestIndexField_indexField_LatLonOptions_latLonOptions_FacetEnabled.Value;
                requestIndexField_indexField_LatLonOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LatLonOptions_latLonOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_LatLonOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_LatLonOptions_latLonOptions_ReturnEnabled = cmdletContext.IndexField_LatLonOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_LatLonOptions_latLonOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_LatLonOptions.ReturnEnabled = requestIndexField_indexField_LatLonOptions_latLonOptions_ReturnEnabled.Value;
                requestIndexField_indexField_LatLonOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LatLonOptions_latLonOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_LatLonOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_LatLonOptions_latLonOptions_SearchEnabled = cmdletContext.IndexField_LatLonOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_LatLonOptions_latLonOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_LatLonOptions.SearchEnabled = requestIndexField_indexField_LatLonOptions_latLonOptions_SearchEnabled.Value;
                requestIndexField_indexField_LatLonOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LatLonOptions_latLonOptions_SortEnabled = null;
            if (cmdletContext.IndexField_LatLonOptions_SortEnabled != null)
            {
                requestIndexField_indexField_LatLonOptions_latLonOptions_SortEnabled = cmdletContext.IndexField_LatLonOptions_SortEnabled.Value;
            }
            if (requestIndexField_indexField_LatLonOptions_latLonOptions_SortEnabled != null)
            {
                requestIndexField_indexField_LatLonOptions.SortEnabled = requestIndexField_indexField_LatLonOptions_latLonOptions_SortEnabled.Value;
                requestIndexField_indexField_LatLonOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_LatLonOptions_latLonOptions_SourceField = null;
            if (cmdletContext.IndexField_LatLonOptions_SourceField != null)
            {
                requestIndexField_indexField_LatLonOptions_latLonOptions_SourceField = cmdletContext.IndexField_LatLonOptions_SourceField;
            }
            if (requestIndexField_indexField_LatLonOptions_latLonOptions_SourceField != null)
            {
                requestIndexField_indexField_LatLonOptions.SourceField = requestIndexField_indexField_LatLonOptions_latLonOptions_SourceField;
                requestIndexField_indexField_LatLonOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_LatLonOptions should be set to null
            if (requestIndexField_indexField_LatLonOptionsIsNull)
            {
                requestIndexField_indexField_LatLonOptions = null;
            }
            if (requestIndexField_indexField_LatLonOptions != null)
            {
                request.IndexField.LatLonOptions = requestIndexField_indexField_LatLonOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.LiteralOptions requestIndexField_indexField_LiteralOptions = null;
            
             // populate LiteralOptions
            bool requestIndexField_indexField_LiteralOptionsIsNull = true;
            requestIndexField_indexField_LiteralOptions = new Amazon.CloudSearch.Model.LiteralOptions();
            System.String requestIndexField_indexField_LiteralOptions_literalOptions_DefaultValue = null;
            if (cmdletContext.IndexField_LiteralOptions_DefaultValue != null)
            {
                requestIndexField_indexField_LiteralOptions_literalOptions_DefaultValue = cmdletContext.IndexField_LiteralOptions_DefaultValue;
            }
            if (requestIndexField_indexField_LiteralOptions_literalOptions_DefaultValue != null)
            {
                requestIndexField_indexField_LiteralOptions.DefaultValue = requestIndexField_indexField_LiteralOptions_literalOptions_DefaultValue;
                requestIndexField_indexField_LiteralOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LiteralOptions_literalOptions_FacetEnabled = null;
            if (cmdletContext.IndexField_LiteralOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_LiteralOptions_literalOptions_FacetEnabled = cmdletContext.IndexField_LiteralOptions_FacetEnabled.Value;
            }
            if (requestIndexField_indexField_LiteralOptions_literalOptions_FacetEnabled != null)
            {
                requestIndexField_indexField_LiteralOptions.FacetEnabled = requestIndexField_indexField_LiteralOptions_literalOptions_FacetEnabled.Value;
                requestIndexField_indexField_LiteralOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LiteralOptions_literalOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_LiteralOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_LiteralOptions_literalOptions_ReturnEnabled = cmdletContext.IndexField_LiteralOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_LiteralOptions_literalOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_LiteralOptions.ReturnEnabled = requestIndexField_indexField_LiteralOptions_literalOptions_ReturnEnabled.Value;
                requestIndexField_indexField_LiteralOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LiteralOptions_literalOptions_SearchEnabled = null;
            if (cmdletContext.IndexField_LiteralOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_LiteralOptions_literalOptions_SearchEnabled = cmdletContext.IndexField_LiteralOptions_SearchEnabled.Value;
            }
            if (requestIndexField_indexField_LiteralOptions_literalOptions_SearchEnabled != null)
            {
                requestIndexField_indexField_LiteralOptions.SearchEnabled = requestIndexField_indexField_LiteralOptions_literalOptions_SearchEnabled.Value;
                requestIndexField_indexField_LiteralOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_LiteralOptions_literalOptions_SortEnabled = null;
            if (cmdletContext.IndexField_LiteralOptions_SortEnabled != null)
            {
                requestIndexField_indexField_LiteralOptions_literalOptions_SortEnabled = cmdletContext.IndexField_LiteralOptions_SortEnabled.Value;
            }
            if (requestIndexField_indexField_LiteralOptions_literalOptions_SortEnabled != null)
            {
                requestIndexField_indexField_LiteralOptions.SortEnabled = requestIndexField_indexField_LiteralOptions_literalOptions_SortEnabled.Value;
                requestIndexField_indexField_LiteralOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_LiteralOptions_literalOptions_SourceField = null;
            if (cmdletContext.IndexField_LiteralOptions_SourceField != null)
            {
                requestIndexField_indexField_LiteralOptions_literalOptions_SourceField = cmdletContext.IndexField_LiteralOptions_SourceField;
            }
            if (requestIndexField_indexField_LiteralOptions_literalOptions_SourceField != null)
            {
                requestIndexField_indexField_LiteralOptions.SourceField = requestIndexField_indexField_LiteralOptions_literalOptions_SourceField;
                requestIndexField_indexField_LiteralOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_LiteralOptions should be set to null
            if (requestIndexField_indexField_LiteralOptionsIsNull)
            {
                requestIndexField_indexField_LiteralOptions = null;
            }
            if (requestIndexField_indexField_LiteralOptions != null)
            {
                request.IndexField.LiteralOptions = requestIndexField_indexField_LiteralOptions;
                requestIndexFieldIsNull = false;
            }
            Amazon.CloudSearch.Model.TextOptions requestIndexField_indexField_TextOptions = null;
            
             // populate TextOptions
            bool requestIndexField_indexField_TextOptionsIsNull = true;
            requestIndexField_indexField_TextOptions = new Amazon.CloudSearch.Model.TextOptions();
            System.String requestIndexField_indexField_TextOptions_textOptions_AnalysisScheme = null;
            if (cmdletContext.IndexField_TextOptions_AnalysisScheme != null)
            {
                requestIndexField_indexField_TextOptions_textOptions_AnalysisScheme = cmdletContext.IndexField_TextOptions_AnalysisScheme;
            }
            if (requestIndexField_indexField_TextOptions_textOptions_AnalysisScheme != null)
            {
                requestIndexField_indexField_TextOptions.AnalysisScheme = requestIndexField_indexField_TextOptions_textOptions_AnalysisScheme;
                requestIndexField_indexField_TextOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_TextOptions_textOptions_DefaultValue = null;
            if (cmdletContext.IndexField_TextOptions_DefaultValue != null)
            {
                requestIndexField_indexField_TextOptions_textOptions_DefaultValue = cmdletContext.IndexField_TextOptions_DefaultValue;
            }
            if (requestIndexField_indexField_TextOptions_textOptions_DefaultValue != null)
            {
                requestIndexField_indexField_TextOptions.DefaultValue = requestIndexField_indexField_TextOptions_textOptions_DefaultValue;
                requestIndexField_indexField_TextOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_TextOptions_textOptions_HighlightEnabled = null;
            if (cmdletContext.IndexField_TextOptions_HighlightEnabled != null)
            {
                requestIndexField_indexField_TextOptions_textOptions_HighlightEnabled = cmdletContext.IndexField_TextOptions_HighlightEnabled.Value;
            }
            if (requestIndexField_indexField_TextOptions_textOptions_HighlightEnabled != null)
            {
                requestIndexField_indexField_TextOptions.HighlightEnabled = requestIndexField_indexField_TextOptions_textOptions_HighlightEnabled.Value;
                requestIndexField_indexField_TextOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_TextOptions_textOptions_ReturnEnabled = null;
            if (cmdletContext.IndexField_TextOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_TextOptions_textOptions_ReturnEnabled = cmdletContext.IndexField_TextOptions_ReturnEnabled.Value;
            }
            if (requestIndexField_indexField_TextOptions_textOptions_ReturnEnabled != null)
            {
                requestIndexField_indexField_TextOptions.ReturnEnabled = requestIndexField_indexField_TextOptions_textOptions_ReturnEnabled.Value;
                requestIndexField_indexField_TextOptionsIsNull = false;
            }
            System.Boolean? requestIndexField_indexField_TextOptions_textOptions_SortEnabled = null;
            if (cmdletContext.IndexField_TextOptions_SortEnabled != null)
            {
                requestIndexField_indexField_TextOptions_textOptions_SortEnabled = cmdletContext.IndexField_TextOptions_SortEnabled.Value;
            }
            if (requestIndexField_indexField_TextOptions_textOptions_SortEnabled != null)
            {
                requestIndexField_indexField_TextOptions.SortEnabled = requestIndexField_indexField_TextOptions_textOptions_SortEnabled.Value;
                requestIndexField_indexField_TextOptionsIsNull = false;
            }
            System.String requestIndexField_indexField_TextOptions_textOptions_SourceField = null;
            if (cmdletContext.IndexField_TextOptions_SourceField != null)
            {
                requestIndexField_indexField_TextOptions_textOptions_SourceField = cmdletContext.IndexField_TextOptions_SourceField;
            }
            if (requestIndexField_indexField_TextOptions_textOptions_SourceField != null)
            {
                requestIndexField_indexField_TextOptions.SourceField = requestIndexField_indexField_TextOptions_textOptions_SourceField;
                requestIndexField_indexField_TextOptionsIsNull = false;
            }
             // determine if requestIndexField_indexField_TextOptions should be set to null
            if (requestIndexField_indexField_TextOptionsIsNull)
            {
                requestIndexField_indexField_TextOptions = null;
            }
            if (requestIndexField_indexField_TextOptions != null)
            {
                request.IndexField.TextOptions = requestIndexField_indexField_TextOptions;
                requestIndexFieldIsNull = false;
            }
             // determine if request.IndexField should be set to null
            if (requestIndexFieldIsNull)
            {
                request.IndexField = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.IndexField;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudSearch.Model.DefineIndexFieldResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.DefineIndexFieldRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearch", "DefineIndexField");
            #if DESKTOP
            return client.DefineIndexField(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DefineIndexFieldAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String DomainName { get; set; }
            public System.String IndexField_DateArrayOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_DateArrayOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_DateArrayOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_DateArrayOptions_SearchEnabled { get; set; }
            public System.String IndexField_DateArrayOptions_SourceFields { get; set; }
            public System.String IndexField_DateOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_DateOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_DateOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_DateOptions_SearchEnabled { get; set; }
            public System.Boolean? IndexField_DateOptions_SortEnabled { get; set; }
            public System.String IndexField_DateOptions_SourceField { get; set; }
            public System.Double? IndexField_DoubleArrayOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_DoubleArrayOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_DoubleArrayOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_DoubleArrayOptions_SearchEnabled { get; set; }
            public System.String IndexField_DoubleArrayOptions_SourceFields { get; set; }
            public System.Double? IndexField_DoubleOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_DoubleOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_DoubleOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_DoubleOptions_SearchEnabled { get; set; }
            public System.Boolean? IndexField_DoubleOptions_SortEnabled { get; set; }
            public System.String IndexField_DoubleOptions_SourceField { get; set; }
            public System.String IndexField_IndexFieldName { get; set; }
            public Amazon.CloudSearch.IndexFieldType IndexField_IndexFieldType { get; set; }
            public System.Int64? IndexField_IntArrayOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_IntArrayOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_IntArrayOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_IntArrayOptions_SearchEnabled { get; set; }
            public System.String IndexField_IntArrayOptions_SourceFields { get; set; }
            public System.Int64? IndexField_IntOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_IntOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_IntOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_IntOptions_SearchEnabled { get; set; }
            public System.Boolean? IndexField_IntOptions_SortEnabled { get; set; }
            public System.String IndexField_IntOptions_SourceField { get; set; }
            public System.String IndexField_LatLonOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_LatLonOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_LatLonOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_LatLonOptions_SearchEnabled { get; set; }
            public System.Boolean? IndexField_LatLonOptions_SortEnabled { get; set; }
            public System.String IndexField_LatLonOptions_SourceField { get; set; }
            public System.String IndexField_LiteralArrayOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_LiteralArrayOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_LiteralArrayOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_LiteralArrayOptions_SearchEnabled { get; set; }
            public System.String IndexField_LiteralArrayOptions_SourceFields { get; set; }
            public System.String IndexField_LiteralOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_LiteralOptions_FacetEnabled { get; set; }
            public System.Boolean? IndexField_LiteralOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_LiteralOptions_SearchEnabled { get; set; }
            public System.Boolean? IndexField_LiteralOptions_SortEnabled { get; set; }
            public System.String IndexField_LiteralOptions_SourceField { get; set; }
            public System.String IndexField_TextArrayOptions_AnalysisScheme { get; set; }
            public System.String IndexField_TextArrayOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_TextArrayOptions_HighlightEnabled { get; set; }
            public System.Boolean? IndexField_TextArrayOptions_ReturnEnabled { get; set; }
            public System.String IndexField_TextArrayOptions_SourceFields { get; set; }
            public System.String IndexField_TextOptions_AnalysisScheme { get; set; }
            public System.String IndexField_TextOptions_DefaultValue { get; set; }
            public System.Boolean? IndexField_TextOptions_HighlightEnabled { get; set; }
            public System.Boolean? IndexField_TextOptions_ReturnEnabled { get; set; }
            public System.Boolean? IndexField_TextOptions_SortEnabled { get; set; }
            public System.String IndexField_TextOptions_SourceField { get; set; }
        }
        
    }
}
