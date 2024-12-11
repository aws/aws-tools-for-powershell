/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.B2bi;
using Amazon.B2bi.Model;

namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Updates the specified parameters for a transformer. A transformer can take an EDI
    /// file as input and transform it into a JSON-or XML-formatted document. Alternatively,
    /// a transformer can take a JSON-or XML-formatted document as input and transform it
    /// into an EDI file.
    /// </summary>
    [Cmdlet("Update", "B2BITransformer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.B2bi.Model.UpdateTransformerResponse")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange UpdateTransformer API operation.", Operation = new[] {"UpdateTransformer"}, SelectReturnType = typeof(Amazon.B2bi.Model.UpdateTransformerResponse))]
    [AWSCmdletOutput("Amazon.B2bi.Model.UpdateTransformerResponse",
        "This cmdlet returns an Amazon.B2bi.Model.UpdateTransformerResponse object containing multiple properties."
    )]
    public partial class UpdateB2BITransformerCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SampleDocuments_BucketName
        /// <summary>
        /// <para>
        /// <para>Contains the Amazon S3 bucket that is used to hold your sample documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SampleDocuments_BucketName { get; set; }
        #endregion
        
        #region Parameter InputConversion_FromFormat
        /// <summary>
        /// <para>
        /// <para>The format for the transformer input: currently on <c>X12</c> is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.B2bi.FromFormat")]
        public Amazon.B2bi.FromFormat InputConversion_FromFormat { get; set; }
        #endregion
        
        #region Parameter SampleDocuments_Key
        /// <summary>
        /// <para>
        /// <para>Contains an array of the Amazon S3 keys used to identify the location for your sample
        /// documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SampleDocuments_Keys")]
        public Amazon.B2bi.Model.SampleDocumentKeys[] SampleDocuments_Key { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specify a new name for the transformer, if you want to update it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Specifies the transformer's status. You can update the state of the transformer from
        /// <c>inactive</c> to <c>active</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.B2bi.TransformerStatus")]
        public Amazon.B2bi.TransformerStatus Status { get; set; }
        #endregion
        
        #region Parameter Mapping_Template
        /// <summary>
        /// <para>
        /// <para>A string that represents the mapping template, in the transformation language specified
        /// in <c>templateLanguage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Mapping_Template { get; set; }
        #endregion
        
        #region Parameter Mapping_TemplateLanguage
        /// <summary>
        /// <para>
        /// <para>The transformation language for the template, either XSLT or JSONATA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.B2bi.MappingTemplateLanguage")]
        public Amazon.B2bi.MappingTemplateLanguage Mapping_TemplateLanguage { get; set; }
        #endregion
        
        #region Parameter OutputConversion_ToFormat
        /// <summary>
        /// <para>
        /// <para>The format for the output from an outbound transformer: only X12 is currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.B2bi.ToFormat")]
        public Amazon.B2bi.ToFormat OutputConversion_ToFormat { get; set; }
        #endregion
        
        #region Parameter X12Details_TransactionSet
        /// <summary>
        /// <para>
        /// <para>Returns an enumerated type where each value identifies an X12 transaction set. Transaction
        /// sets are maintained by the X12 Accredited Standards Committee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdiType_X12Details_TransactionSet")]
        [AWSConstantClassSource("Amazon.B2bi.X12TransactionSet")]
        public Amazon.B2bi.X12TransactionSet X12Details_TransactionSet { get; set; }
        #endregion
        
        #region Parameter InputConversion_FormatOptions_X12_TransactionSet
        /// <summary>
        /// <para>
        /// <para>Returns an enumerated type where each value identifies an X12 transaction set. Transaction
        /// sets are maintained by the X12 Accredited Standards Committee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.B2bi.X12TransactionSet")]
        public Amazon.B2bi.X12TransactionSet InputConversion_FormatOptions_X12_TransactionSet { get; set; }
        #endregion
        
        #region Parameter OutputConversion_FormatOptions_X12_TransactionSet
        /// <summary>
        /// <para>
        /// <para>Returns an enumerated type where each value identifies an X12 transaction set. Transaction
        /// sets are maintained by the X12 Accredited Standards Committee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.B2bi.X12TransactionSet")]
        public Amazon.B2bi.X12TransactionSet OutputConversion_FormatOptions_X12_TransactionSet { get; set; }
        #endregion
        
        #region Parameter TransformerId
        /// <summary>
        /// <para>
        /// <para>Specifies the system-assigned unique identifier for the transformer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TransformerId { get; set; }
        #endregion
        
        #region Parameter X12Details_Version
        /// <summary>
        /// <para>
        /// <para>Returns the version to use for the specified X12 transaction set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdiType_X12Details_Version")]
        [AWSConstantClassSource("Amazon.B2bi.X12Version")]
        public Amazon.B2bi.X12Version X12Details_Version { get; set; }
        #endregion
        
        #region Parameter InputConversion_FormatOptions_X12_Version
        /// <summary>
        /// <para>
        /// <para>Returns the version to use for the specified X12 transaction set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.B2bi.X12Version")]
        public Amazon.B2bi.X12Version InputConversion_FormatOptions_X12_Version { get; set; }
        #endregion
        
        #region Parameter OutputConversion_FormatOptions_X12_Version
        /// <summary>
        /// <para>
        /// <para>Returns the version to use for the specified X12 transaction set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.B2bi.X12Version")]
        public Amazon.B2bi.X12Version OutputConversion_FormatOptions_X12_Version { get; set; }
        #endregion
        
        #region Parameter FileFormat
        /// <summary>
        /// <para>
        /// <para>Specifies that the currently supported file formats for EDI transformations are <c>JSON</c>
        /// and <c>XML</c>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This is a legacy trait. Please use input-conversion or output-conversion.")]
        [AWSConstantClassSource("Amazon.B2bi.FileFormat")]
        public Amazon.B2bi.FileFormat FileFormat { get; set; }
        #endregion
        
        #region Parameter MappingTemplate
        /// <summary>
        /// <para>
        /// <para>Specifies the mapping template for the transformer. This template is used to map the
        /// parsed EDI file using JSONata or XSLT.</para><note><para>This parameter is available for backwards compatibility. Use the <a href="https://docs.aws.amazon.com/b2bi/latest/APIReference/API_Mapping.html">Mapping</a>
        /// data type instead.</para></note>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This is a legacy trait. Please use input-conversion or output-conversion.")]
        public System.String MappingTemplate { get; set; }
        #endregion
        
        #region Parameter SampleDocument
        /// <summary>
        /// <para>
        /// <para>Specifies a sample EDI document that is used by a transformer as a guide for processing
        /// the EDI data.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This is a legacy trait. Please use input-conversion or output-conversion.")]
        public System.String SampleDocument { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.UpdateTransformerResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.UpdateTransformerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransformerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-B2BITransformer (UpdateTransformer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.UpdateTransformerResponse, UpdateB2BITransformerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.X12Details_TransactionSet = this.X12Details_TransactionSet;
            context.X12Details_Version = this.X12Details_Version;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FileFormat = this.FileFormat;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InputConversion_FormatOptions_X12_TransactionSet = this.InputConversion_FormatOptions_X12_TransactionSet;
            context.InputConversion_FormatOptions_X12_Version = this.InputConversion_FormatOptions_X12_Version;
            context.InputConversion_FromFormat = this.InputConversion_FromFormat;
            context.Mapping_Template = this.Mapping_Template;
            context.Mapping_TemplateLanguage = this.Mapping_TemplateLanguage;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MappingTemplate = this.MappingTemplate;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            context.OutputConversion_FormatOptions_X12_TransactionSet = this.OutputConversion_FormatOptions_X12_TransactionSet;
            context.OutputConversion_FormatOptions_X12_Version = this.OutputConversion_FormatOptions_X12_Version;
            context.OutputConversion_ToFormat = this.OutputConversion_ToFormat;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SampleDocument = this.SampleDocument;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SampleDocuments_BucketName = this.SampleDocuments_BucketName;
            if (this.SampleDocuments_Key != null)
            {
                context.SampleDocuments_Key = new List<Amazon.B2bi.Model.SampleDocumentKeys>(this.SampleDocuments_Key);
            }
            context.Status = this.Status;
            context.TransformerId = this.TransformerId;
            #if MODULAR
            if (this.TransformerId == null && ParameterWasBound(nameof(this.TransformerId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.B2bi.Model.UpdateTransformerRequest();
            
            
             // populate EdiType
            var requestEdiTypeIsNull = true;
            request.EdiType = new Amazon.B2bi.Model.EdiType();
            Amazon.B2bi.Model.X12Details requestEdiType_ediType_X12Details = null;
            
             // populate X12Details
            var requestEdiType_ediType_X12DetailsIsNull = true;
            requestEdiType_ediType_X12Details = new Amazon.B2bi.Model.X12Details();
            Amazon.B2bi.X12TransactionSet requestEdiType_ediType_X12Details_x12Details_TransactionSet = null;
            if (cmdletContext.X12Details_TransactionSet != null)
            {
                requestEdiType_ediType_X12Details_x12Details_TransactionSet = cmdletContext.X12Details_TransactionSet;
            }
            if (requestEdiType_ediType_X12Details_x12Details_TransactionSet != null)
            {
                requestEdiType_ediType_X12Details.TransactionSet = requestEdiType_ediType_X12Details_x12Details_TransactionSet;
                requestEdiType_ediType_X12DetailsIsNull = false;
            }
            Amazon.B2bi.X12Version requestEdiType_ediType_X12Details_x12Details_Version = null;
            if (cmdletContext.X12Details_Version != null)
            {
                requestEdiType_ediType_X12Details_x12Details_Version = cmdletContext.X12Details_Version;
            }
            if (requestEdiType_ediType_X12Details_x12Details_Version != null)
            {
                requestEdiType_ediType_X12Details.Version = requestEdiType_ediType_X12Details_x12Details_Version;
                requestEdiType_ediType_X12DetailsIsNull = false;
            }
             // determine if requestEdiType_ediType_X12Details should be set to null
            if (requestEdiType_ediType_X12DetailsIsNull)
            {
                requestEdiType_ediType_X12Details = null;
            }
            if (requestEdiType_ediType_X12Details != null)
            {
                request.EdiType.X12Details = requestEdiType_ediType_X12Details;
                requestEdiTypeIsNull = false;
            }
             // determine if request.EdiType should be set to null
            if (requestEdiTypeIsNull)
            {
                request.EdiType = null;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.FileFormat != null)
            {
                request.FileFormat = cmdletContext.FileFormat;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
             // populate InputConversion
            var requestInputConversionIsNull = true;
            request.InputConversion = new Amazon.B2bi.Model.InputConversion();
            Amazon.B2bi.FromFormat requestInputConversion_inputConversion_FromFormat = null;
            if (cmdletContext.InputConversion_FromFormat != null)
            {
                requestInputConversion_inputConversion_FromFormat = cmdletContext.InputConversion_FromFormat;
            }
            if (requestInputConversion_inputConversion_FromFormat != null)
            {
                request.InputConversion.FromFormat = requestInputConversion_inputConversion_FromFormat;
                requestInputConversionIsNull = false;
            }
            Amazon.B2bi.Model.FormatOptions requestInputConversion_inputConversion_FormatOptions = null;
            
             // populate FormatOptions
            var requestInputConversion_inputConversion_FormatOptionsIsNull = true;
            requestInputConversion_inputConversion_FormatOptions = new Amazon.B2bi.Model.FormatOptions();
            Amazon.B2bi.Model.X12Details requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12 = null;
            
             // populate X12
            var requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12IsNull = true;
            requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12 = new Amazon.B2bi.Model.X12Details();
            Amazon.B2bi.X12TransactionSet requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12_inputConversion_FormatOptions_X12_TransactionSet = null;
            if (cmdletContext.InputConversion_FormatOptions_X12_TransactionSet != null)
            {
                requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12_inputConversion_FormatOptions_X12_TransactionSet = cmdletContext.InputConversion_FormatOptions_X12_TransactionSet;
            }
            if (requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12_inputConversion_FormatOptions_X12_TransactionSet != null)
            {
                requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12.TransactionSet = requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12_inputConversion_FormatOptions_X12_TransactionSet;
                requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12IsNull = false;
            }
            Amazon.B2bi.X12Version requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12_inputConversion_FormatOptions_X12_Version = null;
            if (cmdletContext.InputConversion_FormatOptions_X12_Version != null)
            {
                requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12_inputConversion_FormatOptions_X12_Version = cmdletContext.InputConversion_FormatOptions_X12_Version;
            }
            if (requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12_inputConversion_FormatOptions_X12_Version != null)
            {
                requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12.Version = requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12_inputConversion_FormatOptions_X12_Version;
                requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12IsNull = false;
            }
             // determine if requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12 should be set to null
            if (requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12IsNull)
            {
                requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12 = null;
            }
            if (requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12 != null)
            {
                requestInputConversion_inputConversion_FormatOptions.X12 = requestInputConversion_inputConversion_FormatOptions_inputConversion_FormatOptions_X12;
                requestInputConversion_inputConversion_FormatOptionsIsNull = false;
            }
             // determine if requestInputConversion_inputConversion_FormatOptions should be set to null
            if (requestInputConversion_inputConversion_FormatOptionsIsNull)
            {
                requestInputConversion_inputConversion_FormatOptions = null;
            }
            if (requestInputConversion_inputConversion_FormatOptions != null)
            {
                request.InputConversion.FormatOptions = requestInputConversion_inputConversion_FormatOptions;
                requestInputConversionIsNull = false;
            }
             // determine if request.InputConversion should be set to null
            if (requestInputConversionIsNull)
            {
                request.InputConversion = null;
            }
            
             // populate Mapping
            var requestMappingIsNull = true;
            request.Mapping = new Amazon.B2bi.Model.Mapping();
            System.String requestMapping_mapping_Template = null;
            if (cmdletContext.Mapping_Template != null)
            {
                requestMapping_mapping_Template = cmdletContext.Mapping_Template;
            }
            if (requestMapping_mapping_Template != null)
            {
                request.Mapping.Template = requestMapping_mapping_Template;
                requestMappingIsNull = false;
            }
            Amazon.B2bi.MappingTemplateLanguage requestMapping_mapping_TemplateLanguage = null;
            if (cmdletContext.Mapping_TemplateLanguage != null)
            {
                requestMapping_mapping_TemplateLanguage = cmdletContext.Mapping_TemplateLanguage;
            }
            if (requestMapping_mapping_TemplateLanguage != null)
            {
                request.Mapping.TemplateLanguage = requestMapping_mapping_TemplateLanguage;
                requestMappingIsNull = false;
            }
             // determine if request.Mapping should be set to null
            if (requestMappingIsNull)
            {
                request.Mapping = null;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.MappingTemplate != null)
            {
                request.MappingTemplate = cmdletContext.MappingTemplate;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputConversion
            var requestOutputConversionIsNull = true;
            request.OutputConversion = new Amazon.B2bi.Model.OutputConversion();
            Amazon.B2bi.ToFormat requestOutputConversion_outputConversion_ToFormat = null;
            if (cmdletContext.OutputConversion_ToFormat != null)
            {
                requestOutputConversion_outputConversion_ToFormat = cmdletContext.OutputConversion_ToFormat;
            }
            if (requestOutputConversion_outputConversion_ToFormat != null)
            {
                request.OutputConversion.ToFormat = requestOutputConversion_outputConversion_ToFormat;
                requestOutputConversionIsNull = false;
            }
            Amazon.B2bi.Model.FormatOptions requestOutputConversion_outputConversion_FormatOptions = null;
            
             // populate FormatOptions
            var requestOutputConversion_outputConversion_FormatOptionsIsNull = true;
            requestOutputConversion_outputConversion_FormatOptions = new Amazon.B2bi.Model.FormatOptions();
            Amazon.B2bi.Model.X12Details requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12 = null;
            
             // populate X12
            var requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12IsNull = true;
            requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12 = new Amazon.B2bi.Model.X12Details();
            Amazon.B2bi.X12TransactionSet requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12_outputConversion_FormatOptions_X12_TransactionSet = null;
            if (cmdletContext.OutputConversion_FormatOptions_X12_TransactionSet != null)
            {
                requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12_outputConversion_FormatOptions_X12_TransactionSet = cmdletContext.OutputConversion_FormatOptions_X12_TransactionSet;
            }
            if (requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12_outputConversion_FormatOptions_X12_TransactionSet != null)
            {
                requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12.TransactionSet = requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12_outputConversion_FormatOptions_X12_TransactionSet;
                requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12IsNull = false;
            }
            Amazon.B2bi.X12Version requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12_outputConversion_FormatOptions_X12_Version = null;
            if (cmdletContext.OutputConversion_FormatOptions_X12_Version != null)
            {
                requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12_outputConversion_FormatOptions_X12_Version = cmdletContext.OutputConversion_FormatOptions_X12_Version;
            }
            if (requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12_outputConversion_FormatOptions_X12_Version != null)
            {
                requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12.Version = requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12_outputConversion_FormatOptions_X12_Version;
                requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12IsNull = false;
            }
             // determine if requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12 should be set to null
            if (requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12IsNull)
            {
                requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12 = null;
            }
            if (requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12 != null)
            {
                requestOutputConversion_outputConversion_FormatOptions.X12 = requestOutputConversion_outputConversion_FormatOptions_outputConversion_FormatOptions_X12;
                requestOutputConversion_outputConversion_FormatOptionsIsNull = false;
            }
             // determine if requestOutputConversion_outputConversion_FormatOptions should be set to null
            if (requestOutputConversion_outputConversion_FormatOptionsIsNull)
            {
                requestOutputConversion_outputConversion_FormatOptions = null;
            }
            if (requestOutputConversion_outputConversion_FormatOptions != null)
            {
                request.OutputConversion.FormatOptions = requestOutputConversion_outputConversion_FormatOptions;
                requestOutputConversionIsNull = false;
            }
             // determine if request.OutputConversion should be set to null
            if (requestOutputConversionIsNull)
            {
                request.OutputConversion = null;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.SampleDocument != null)
            {
                request.SampleDocument = cmdletContext.SampleDocument;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
             // populate SampleDocuments
            var requestSampleDocumentsIsNull = true;
            request.SampleDocuments = new Amazon.B2bi.Model.SampleDocuments();
            System.String requestSampleDocuments_sampleDocuments_BucketName = null;
            if (cmdletContext.SampleDocuments_BucketName != null)
            {
                requestSampleDocuments_sampleDocuments_BucketName = cmdletContext.SampleDocuments_BucketName;
            }
            if (requestSampleDocuments_sampleDocuments_BucketName != null)
            {
                request.SampleDocuments.BucketName = requestSampleDocuments_sampleDocuments_BucketName;
                requestSampleDocumentsIsNull = false;
            }
            List<Amazon.B2bi.Model.SampleDocumentKeys> requestSampleDocuments_sampleDocuments_Key = null;
            if (cmdletContext.SampleDocuments_Key != null)
            {
                requestSampleDocuments_sampleDocuments_Key = cmdletContext.SampleDocuments_Key;
            }
            if (requestSampleDocuments_sampleDocuments_Key != null)
            {
                request.SampleDocuments.Keys = requestSampleDocuments_sampleDocuments_Key;
                requestSampleDocumentsIsNull = false;
            }
             // determine if request.SampleDocuments should be set to null
            if (requestSampleDocumentsIsNull)
            {
                request.SampleDocuments = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TransformerId != null)
            {
                request.TransformerId = cmdletContext.TransformerId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.B2bi.Model.UpdateTransformerResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.UpdateTransformerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "UpdateTransformer");
            try
            {
                #if DESKTOP
                return client.UpdateTransformer(request);
                #elif CORECLR
                return client.UpdateTransformerAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.B2bi.X12TransactionSet X12Details_TransactionSet { get; set; }
            public Amazon.B2bi.X12Version X12Details_Version { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.B2bi.FileFormat FileFormat { get; set; }
            public Amazon.B2bi.X12TransactionSet InputConversion_FormatOptions_X12_TransactionSet { get; set; }
            public Amazon.B2bi.X12Version InputConversion_FormatOptions_X12_Version { get; set; }
            public Amazon.B2bi.FromFormat InputConversion_FromFormat { get; set; }
            public System.String Mapping_Template { get; set; }
            public Amazon.B2bi.MappingTemplateLanguage Mapping_TemplateLanguage { get; set; }
            [System.ObsoleteAttribute]
            public System.String MappingTemplate { get; set; }
            public System.String Name { get; set; }
            public Amazon.B2bi.X12TransactionSet OutputConversion_FormatOptions_X12_TransactionSet { get; set; }
            public Amazon.B2bi.X12Version OutputConversion_FormatOptions_X12_Version { get; set; }
            public Amazon.B2bi.ToFormat OutputConversion_ToFormat { get; set; }
            [System.ObsoleteAttribute]
            public System.String SampleDocument { get; set; }
            public System.String SampleDocuments_BucketName { get; set; }
            public List<Amazon.B2bi.Model.SampleDocumentKeys> SampleDocuments_Key { get; set; }
            public Amazon.B2bi.TransformerStatus Status { get; set; }
            public System.String TransformerId { get; set; }
            public System.Func<Amazon.B2bi.Model.UpdateTransformerResponse, UpdateB2BITransformerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
