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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Modifies an existing classifier (a <code>GrokClassifier</code>, an <code>XMLClassifier</code>,
    /// a <code>JsonClassifier</code>, or a <code>CsvClassifier</code>, depending on which
    /// field is present).
    /// </summary>
    [Cmdlet("Update", "GLUEClassifier", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue UpdateClassifier API operation.", Operation = new[] {"UpdateClassifier"}, SelectReturnType = typeof(Amazon.Glue.Model.UpdateClassifierResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.UpdateClassifierResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.UpdateClassifierResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGLUEClassifierCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter CsvClassifier_AllowSingleColumn
        /// <summary>
        /// <para>
        /// <para>Enables the processing of files that contain only one column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CsvClassifier_AllowSingleColumn { get; set; }
        #endregion
        
        #region Parameter CsvClassifier_ContainsHeader
        /// <summary>
        /// <para>
        /// <para>Indicates whether the CSV file contains a header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.CsvHeaderOption")]
        public Amazon.Glue.CsvHeaderOption CsvClassifier_ContainsHeader { get; set; }
        #endregion
        
        #region Parameter CsvClassifier_CustomDatatypeConfigured
        /// <summary>
        /// <para>
        /// <para>Specifies the configuration of custom datatypes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CsvClassifier_CustomDatatypeConfigured { get; set; }
        #endregion
        
        #region Parameter CsvClassifier_CustomDatatype
        /// <summary>
        /// <para>
        /// <para>Specifies a list of supported custom datatypes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CsvClassifier_CustomDatatypes")]
        public System.String[] CsvClassifier_CustomDatatype { get; set; }
        #endregion
        
        #region Parameter CsvClassifier_Delimiter
        /// <summary>
        /// <para>
        /// <para>A custom symbol to denote what separates each column entry in the row.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CsvClassifier_Delimiter { get; set; }
        #endregion
        
        #region Parameter CsvClassifier_DisableValueTrimming
        /// <summary>
        /// <para>
        /// <para>Specifies not to trim values before identifying the type of column values. The default
        /// value is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CsvClassifier_DisableValueTrimming { get; set; }
        #endregion
        
        #region Parameter GrokClassifier
        /// <summary>
        /// <para>
        /// <para>A <code>GrokClassifier</code> object with updated fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Glue.Model.UpdateGrokClassifierRequest GrokClassifier { get; set; }
        #endregion
        
        #region Parameter CsvClassifier_Header
        /// <summary>
        /// <para>
        /// <para>A list of strings representing column names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CsvClassifier_Header { get; set; }
        #endregion
        
        #region Parameter JsonClassifier_JsonPath
        /// <summary>
        /// <para>
        /// <para>A <code>JsonPath</code> string defining the JSON data for the classifier to classify.
        /// Glue supports a subset of JsonPath, as described in <a href="https://docs.aws.amazon.com/glue/latest/dg/custom-classifier.html#custom-classifier-json">Writing
        /// JsonPath Custom Classifiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JsonClassifier_JsonPath { get; set; }
        #endregion
        
        #region Parameter CsvClassifier_Name
        /// <summary>
        /// <para>
        /// <para>The name of the classifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CsvClassifier_Name { get; set; }
        #endregion
        
        #region Parameter JsonClassifier_Name
        /// <summary>
        /// <para>
        /// <para>The name of the classifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JsonClassifier_Name { get; set; }
        #endregion
        
        #region Parameter CsvClassifier_QuoteSymbol
        /// <summary>
        /// <para>
        /// <para>A custom symbol to denote what combines content into a single column value. It must
        /// be different from the column delimiter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CsvClassifier_QuoteSymbol { get; set; }
        #endregion
        
        #region Parameter XMLClassifier
        /// <summary>
        /// <para>
        /// <para>An <code>XMLClassifier</code> object with updated fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Glue.Model.UpdateXMLClassifierRequest XMLClassifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.UpdateClassifierResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUEClassifier (UpdateClassifier)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.UpdateClassifierResponse, UpdateGLUEClassifierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CsvClassifier_AllowSingleColumn = this.CsvClassifier_AllowSingleColumn;
            context.CsvClassifier_ContainsHeader = this.CsvClassifier_ContainsHeader;
            context.CsvClassifier_CustomDatatypeConfigured = this.CsvClassifier_CustomDatatypeConfigured;
            if (this.CsvClassifier_CustomDatatype != null)
            {
                context.CsvClassifier_CustomDatatype = new List<System.String>(this.CsvClassifier_CustomDatatype);
            }
            context.CsvClassifier_Delimiter = this.CsvClassifier_Delimiter;
            context.CsvClassifier_DisableValueTrimming = this.CsvClassifier_DisableValueTrimming;
            if (this.CsvClassifier_Header != null)
            {
                context.CsvClassifier_Header = new List<System.String>(this.CsvClassifier_Header);
            }
            context.CsvClassifier_Name = this.CsvClassifier_Name;
            context.CsvClassifier_QuoteSymbol = this.CsvClassifier_QuoteSymbol;
            context.GrokClassifier = this.GrokClassifier;
            context.JsonClassifier_JsonPath = this.JsonClassifier_JsonPath;
            context.JsonClassifier_Name = this.JsonClassifier_Name;
            context.XMLClassifier = this.XMLClassifier;
            
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
            var request = new Amazon.Glue.Model.UpdateClassifierRequest();
            
            
             // populate CsvClassifier
            var requestCsvClassifierIsNull = true;
            request.CsvClassifier = new Amazon.Glue.Model.UpdateCsvClassifierRequest();
            System.Boolean? requestCsvClassifier_csvClassifier_AllowSingleColumn = null;
            if (cmdletContext.CsvClassifier_AllowSingleColumn != null)
            {
                requestCsvClassifier_csvClassifier_AllowSingleColumn = cmdletContext.CsvClassifier_AllowSingleColumn.Value;
            }
            if (requestCsvClassifier_csvClassifier_AllowSingleColumn != null)
            {
                request.CsvClassifier.AllowSingleColumn = requestCsvClassifier_csvClassifier_AllowSingleColumn.Value;
                requestCsvClassifierIsNull = false;
            }
            Amazon.Glue.CsvHeaderOption requestCsvClassifier_csvClassifier_ContainsHeader = null;
            if (cmdletContext.CsvClassifier_ContainsHeader != null)
            {
                requestCsvClassifier_csvClassifier_ContainsHeader = cmdletContext.CsvClassifier_ContainsHeader;
            }
            if (requestCsvClassifier_csvClassifier_ContainsHeader != null)
            {
                request.CsvClassifier.ContainsHeader = requestCsvClassifier_csvClassifier_ContainsHeader;
                requestCsvClassifierIsNull = false;
            }
            System.Boolean? requestCsvClassifier_csvClassifier_CustomDatatypeConfigured = null;
            if (cmdletContext.CsvClassifier_CustomDatatypeConfigured != null)
            {
                requestCsvClassifier_csvClassifier_CustomDatatypeConfigured = cmdletContext.CsvClassifier_CustomDatatypeConfigured.Value;
            }
            if (requestCsvClassifier_csvClassifier_CustomDatatypeConfigured != null)
            {
                request.CsvClassifier.CustomDatatypeConfigured = requestCsvClassifier_csvClassifier_CustomDatatypeConfigured.Value;
                requestCsvClassifierIsNull = false;
            }
            List<System.String> requestCsvClassifier_csvClassifier_CustomDatatype = null;
            if (cmdletContext.CsvClassifier_CustomDatatype != null)
            {
                requestCsvClassifier_csvClassifier_CustomDatatype = cmdletContext.CsvClassifier_CustomDatatype;
            }
            if (requestCsvClassifier_csvClassifier_CustomDatatype != null)
            {
                request.CsvClassifier.CustomDatatypes = requestCsvClassifier_csvClassifier_CustomDatatype;
                requestCsvClassifierIsNull = false;
            }
            System.String requestCsvClassifier_csvClassifier_Delimiter = null;
            if (cmdletContext.CsvClassifier_Delimiter != null)
            {
                requestCsvClassifier_csvClassifier_Delimiter = cmdletContext.CsvClassifier_Delimiter;
            }
            if (requestCsvClassifier_csvClassifier_Delimiter != null)
            {
                request.CsvClassifier.Delimiter = requestCsvClassifier_csvClassifier_Delimiter;
                requestCsvClassifierIsNull = false;
            }
            System.Boolean? requestCsvClassifier_csvClassifier_DisableValueTrimming = null;
            if (cmdletContext.CsvClassifier_DisableValueTrimming != null)
            {
                requestCsvClassifier_csvClassifier_DisableValueTrimming = cmdletContext.CsvClassifier_DisableValueTrimming.Value;
            }
            if (requestCsvClassifier_csvClassifier_DisableValueTrimming != null)
            {
                request.CsvClassifier.DisableValueTrimming = requestCsvClassifier_csvClassifier_DisableValueTrimming.Value;
                requestCsvClassifierIsNull = false;
            }
            List<System.String> requestCsvClassifier_csvClassifier_Header = null;
            if (cmdletContext.CsvClassifier_Header != null)
            {
                requestCsvClassifier_csvClassifier_Header = cmdletContext.CsvClassifier_Header;
            }
            if (requestCsvClassifier_csvClassifier_Header != null)
            {
                request.CsvClassifier.Header = requestCsvClassifier_csvClassifier_Header;
                requestCsvClassifierIsNull = false;
            }
            System.String requestCsvClassifier_csvClassifier_Name = null;
            if (cmdletContext.CsvClassifier_Name != null)
            {
                requestCsvClassifier_csvClassifier_Name = cmdletContext.CsvClassifier_Name;
            }
            if (requestCsvClassifier_csvClassifier_Name != null)
            {
                request.CsvClassifier.Name = requestCsvClassifier_csvClassifier_Name;
                requestCsvClassifierIsNull = false;
            }
            System.String requestCsvClassifier_csvClassifier_QuoteSymbol = null;
            if (cmdletContext.CsvClassifier_QuoteSymbol != null)
            {
                requestCsvClassifier_csvClassifier_QuoteSymbol = cmdletContext.CsvClassifier_QuoteSymbol;
            }
            if (requestCsvClassifier_csvClassifier_QuoteSymbol != null)
            {
                request.CsvClassifier.QuoteSymbol = requestCsvClassifier_csvClassifier_QuoteSymbol;
                requestCsvClassifierIsNull = false;
            }
             // determine if request.CsvClassifier should be set to null
            if (requestCsvClassifierIsNull)
            {
                request.CsvClassifier = null;
            }
            if (cmdletContext.GrokClassifier != null)
            {
                request.GrokClassifier = cmdletContext.GrokClassifier;
            }
            
             // populate JsonClassifier
            var requestJsonClassifierIsNull = true;
            request.JsonClassifier = new Amazon.Glue.Model.UpdateJsonClassifierRequest();
            System.String requestJsonClassifier_jsonClassifier_JsonPath = null;
            if (cmdletContext.JsonClassifier_JsonPath != null)
            {
                requestJsonClassifier_jsonClassifier_JsonPath = cmdletContext.JsonClassifier_JsonPath;
            }
            if (requestJsonClassifier_jsonClassifier_JsonPath != null)
            {
                request.JsonClassifier.JsonPath = requestJsonClassifier_jsonClassifier_JsonPath;
                requestJsonClassifierIsNull = false;
            }
            System.String requestJsonClassifier_jsonClassifier_Name = null;
            if (cmdletContext.JsonClassifier_Name != null)
            {
                requestJsonClassifier_jsonClassifier_Name = cmdletContext.JsonClassifier_Name;
            }
            if (requestJsonClassifier_jsonClassifier_Name != null)
            {
                request.JsonClassifier.Name = requestJsonClassifier_jsonClassifier_Name;
                requestJsonClassifierIsNull = false;
            }
             // determine if request.JsonClassifier should be set to null
            if (requestJsonClassifierIsNull)
            {
                request.JsonClassifier = null;
            }
            if (cmdletContext.XMLClassifier != null)
            {
                request.XMLClassifier = cmdletContext.XMLClassifier;
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
        
        private Amazon.Glue.Model.UpdateClassifierResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateClassifierRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateClassifier");
            try
            {
                #if DESKTOP
                return client.UpdateClassifier(request);
                #elif CORECLR
                return client.UpdateClassifierAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CsvClassifier_AllowSingleColumn { get; set; }
            public Amazon.Glue.CsvHeaderOption CsvClassifier_ContainsHeader { get; set; }
            public System.Boolean? CsvClassifier_CustomDatatypeConfigured { get; set; }
            public List<System.String> CsvClassifier_CustomDatatype { get; set; }
            public System.String CsvClassifier_Delimiter { get; set; }
            public System.Boolean? CsvClassifier_DisableValueTrimming { get; set; }
            public List<System.String> CsvClassifier_Header { get; set; }
            public System.String CsvClassifier_Name { get; set; }
            public System.String CsvClassifier_QuoteSymbol { get; set; }
            public Amazon.Glue.Model.UpdateGrokClassifierRequest GrokClassifier { get; set; }
            public System.String JsonClassifier_JsonPath { get; set; }
            public System.String JsonClassifier_Name { get; set; }
            public Amazon.Glue.Model.UpdateXMLClassifierRequest XMLClassifier { get; set; }
            public System.Func<Amazon.Glue.Model.UpdateClassifierResponse, UpdateGLUEClassifierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
