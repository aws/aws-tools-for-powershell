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
    /// Creates a transformer. A transformer describes how to process the incoming EDI documents
    /// and extract the necessary information to the output file.
    /// </summary>
    [Cmdlet("New", "B2BITransformer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.B2bi.Model.CreateTransformerResponse")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange CreateTransformer API operation.", Operation = new[] {"CreateTransformer"}, SelectReturnType = typeof(Amazon.B2bi.Model.CreateTransformerResponse))]
    [AWSCmdletOutput("Amazon.B2bi.Model.CreateTransformerResponse",
        "This cmdlet returns an Amazon.B2bi.Model.CreateTransformerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewB2BITransformerCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileFormat
        /// <summary>
        /// <para>
        /// <para>Specifies that the currently supported file formats for EDI transformations are <c>JSON</c>
        /// and <c>XML</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.B2bi.FileFormat")]
        public Amazon.B2bi.FileFormat FileFormat { get; set; }
        #endregion
        
        #region Parameter MappingTemplate
        /// <summary>
        /// <para>
        /// <para>Specifies the mapping template for the transformer. This template is used to map the
        /// parsed EDI file using JSONata or XSLT.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MappingTemplate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the transformer, used to identify it.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SampleDocument
        /// <summary>
        /// <para>
        /// <para>Specifies a sample EDI document that is used by a transformer as a guide for processing
        /// the EDI data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SampleDocument { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies the key-value pairs assigned to ARNs that you can use to group and search
        /// for resources by type. You can attach this metadata to resources (capabilities, partnerships,
        /// and so on) for any purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.B2bi.Model.Tag[] Tag { get; set; }
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
        
        #region Parameter X12Details_Version
        /// <summary>
        /// <para>
        /// Amazon.B2bi.Model.X12Details.Version
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdiType_X12Details_Version")]
        [AWSConstantClassSource("Amazon.B2bi.X12Version")]
        public Amazon.B2bi.X12Version X12Details_Version { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.CreateTransformerResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.CreateTransformerResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-B2BITransformer (CreateTransformer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.CreateTransformerResponse, NewB2BITransformerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.X12Details_TransactionSet = this.X12Details_TransactionSet;
            context.X12Details_Version = this.X12Details_Version;
            context.FileFormat = this.FileFormat;
            #if MODULAR
            if (this.FileFormat == null && ParameterWasBound(nameof(this.FileFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter FileFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MappingTemplate = this.MappingTemplate;
            #if MODULAR
            if (this.MappingTemplate == null && ParameterWasBound(nameof(this.MappingTemplate)))
            {
                WriteWarning("You are passing $null as a value for parameter MappingTemplate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SampleDocument = this.SampleDocument;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.B2bi.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.B2bi.Model.CreateTransformerRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
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
            if (cmdletContext.FileFormat != null)
            {
                request.FileFormat = cmdletContext.FileFormat;
            }
            if (cmdletContext.MappingTemplate != null)
            {
                request.MappingTemplate = cmdletContext.MappingTemplate;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SampleDocument != null)
            {
                request.SampleDocument = cmdletContext.SampleDocument;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.B2bi.Model.CreateTransformerResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.CreateTransformerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "CreateTransformer");
            try
            {
                #if DESKTOP
                return client.CreateTransformer(request);
                #elif CORECLR
                return client.CreateTransformerAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.B2bi.X12TransactionSet X12Details_TransactionSet { get; set; }
            public Amazon.B2bi.X12Version X12Details_Version { get; set; }
            public Amazon.B2bi.FileFormat FileFormat { get; set; }
            public System.String MappingTemplate { get; set; }
            public System.String Name { get; set; }
            public System.String SampleDocument { get; set; }
            public List<Amazon.B2bi.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.B2bi.Model.CreateTransformerResponse, NewB2BITransformerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
