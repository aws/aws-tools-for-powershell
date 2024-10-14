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
using Amazon.TaxSettings;
using Amazon.TaxSettings.Model;

namespace Amazon.PowerShell.Cmdlets.TSA
{
    /// <summary>
    /// Downloads your tax documents to the Amazon S3 bucket that you specify in your request.
    /// </summary>
    [Cmdlet("Get", "TSATaxRegistrationDocument")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Tax Settings GetTaxRegistrationDocument API operation.", Operation = new[] {"GetTaxRegistrationDocument"}, SelectReturnType = typeof(Amazon.TaxSettings.Model.GetTaxRegistrationDocumentResponse))]
    [AWSCmdletOutput("System.String or Amazon.TaxSettings.Model.GetTaxRegistrationDocumentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.TaxSettings.Model.GetTaxRegistrationDocumentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTSATaxRegistrationDocumentCmdlet : AmazonTaxSettingsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationS3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of your Amazon S3 bucket that you specify to download your tax documents
        /// to.</para>
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
        public System.String DestinationS3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter DestinationS3Location_Prefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 object prefix that you specify for your tax document file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationS3Location_Prefix { get; set; }
        #endregion
        
        #region Parameter TaxDocumentMetadata_TaxDocumentAccessToken
        /// <summary>
        /// <para>
        /// <para>The tax document access token, which contains information that the Tax Settings API
        /// uses to locate the tax document.</para><note><para>If you update your tax registration, the existing <c>taxDocumentAccessToken</c> won't
        /// be valid. To get the latest token, call the <c>GetTaxRegistration</c> or <c>ListTaxRegistrations</c>
        /// API operation. This token is valid for 24 hours.</para></note>
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
        public System.String TaxDocumentMetadata_TaxDocumentAccessToken { get; set; }
        #endregion
        
        #region Parameter TaxDocumentMetadata_TaxDocumentName
        /// <summary>
        /// <para>
        /// <para>The name of your tax document.</para>
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
        public System.String TaxDocumentMetadata_TaxDocumentName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DestinationFilePath'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TaxSettings.Model.GetTaxRegistrationDocumentResponse).
        /// Specifying the name of a property of type Amazon.TaxSettings.Model.GetTaxRegistrationDocumentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DestinationFilePath";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TaxDocumentMetadata_TaxDocumentName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TaxDocumentMetadata_TaxDocumentName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TaxDocumentMetadata_TaxDocumentName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TaxSettings.Model.GetTaxRegistrationDocumentResponse, GetTSATaxRegistrationDocumentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TaxDocumentMetadata_TaxDocumentName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DestinationS3Location_Bucket = this.DestinationS3Location_Bucket;
            #if MODULAR
            if (this.DestinationS3Location_Bucket == null && ParameterWasBound(nameof(this.DestinationS3Location_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationS3Location_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationS3Location_Prefix = this.DestinationS3Location_Prefix;
            context.TaxDocumentMetadata_TaxDocumentAccessToken = this.TaxDocumentMetadata_TaxDocumentAccessToken;
            #if MODULAR
            if (this.TaxDocumentMetadata_TaxDocumentAccessToken == null && ParameterWasBound(nameof(this.TaxDocumentMetadata_TaxDocumentAccessToken)))
            {
                WriteWarning("You are passing $null as a value for parameter TaxDocumentMetadata_TaxDocumentAccessToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaxDocumentMetadata_TaxDocumentName = this.TaxDocumentMetadata_TaxDocumentName;
            #if MODULAR
            if (this.TaxDocumentMetadata_TaxDocumentName == null && ParameterWasBound(nameof(this.TaxDocumentMetadata_TaxDocumentName)))
            {
                WriteWarning("You are passing $null as a value for parameter TaxDocumentMetadata_TaxDocumentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TaxSettings.Model.GetTaxRegistrationDocumentRequest();
            
            
             // populate DestinationS3Location
            var requestDestinationS3LocationIsNull = true;
            request.DestinationS3Location = new Amazon.TaxSettings.Model.DestinationS3Location();
            System.String requestDestinationS3Location_destinationS3Location_Bucket = null;
            if (cmdletContext.DestinationS3Location_Bucket != null)
            {
                requestDestinationS3Location_destinationS3Location_Bucket = cmdletContext.DestinationS3Location_Bucket;
            }
            if (requestDestinationS3Location_destinationS3Location_Bucket != null)
            {
                request.DestinationS3Location.Bucket = requestDestinationS3Location_destinationS3Location_Bucket;
                requestDestinationS3LocationIsNull = false;
            }
            System.String requestDestinationS3Location_destinationS3Location_Prefix = null;
            if (cmdletContext.DestinationS3Location_Prefix != null)
            {
                requestDestinationS3Location_destinationS3Location_Prefix = cmdletContext.DestinationS3Location_Prefix;
            }
            if (requestDestinationS3Location_destinationS3Location_Prefix != null)
            {
                request.DestinationS3Location.Prefix = requestDestinationS3Location_destinationS3Location_Prefix;
                requestDestinationS3LocationIsNull = false;
            }
             // determine if request.DestinationS3Location should be set to null
            if (requestDestinationS3LocationIsNull)
            {
                request.DestinationS3Location = null;
            }
            
             // populate TaxDocumentMetadata
            var requestTaxDocumentMetadataIsNull = true;
            request.TaxDocumentMetadata = new Amazon.TaxSettings.Model.TaxDocumentMetadata();
            System.String requestTaxDocumentMetadata_taxDocumentMetadata_TaxDocumentAccessToken = null;
            if (cmdletContext.TaxDocumentMetadata_TaxDocumentAccessToken != null)
            {
                requestTaxDocumentMetadata_taxDocumentMetadata_TaxDocumentAccessToken = cmdletContext.TaxDocumentMetadata_TaxDocumentAccessToken;
            }
            if (requestTaxDocumentMetadata_taxDocumentMetadata_TaxDocumentAccessToken != null)
            {
                request.TaxDocumentMetadata.TaxDocumentAccessToken = requestTaxDocumentMetadata_taxDocumentMetadata_TaxDocumentAccessToken;
                requestTaxDocumentMetadataIsNull = false;
            }
            System.String requestTaxDocumentMetadata_taxDocumentMetadata_TaxDocumentName = null;
            if (cmdletContext.TaxDocumentMetadata_TaxDocumentName != null)
            {
                requestTaxDocumentMetadata_taxDocumentMetadata_TaxDocumentName = cmdletContext.TaxDocumentMetadata_TaxDocumentName;
            }
            if (requestTaxDocumentMetadata_taxDocumentMetadata_TaxDocumentName != null)
            {
                request.TaxDocumentMetadata.TaxDocumentName = requestTaxDocumentMetadata_taxDocumentMetadata_TaxDocumentName;
                requestTaxDocumentMetadataIsNull = false;
            }
             // determine if request.TaxDocumentMetadata should be set to null
            if (requestTaxDocumentMetadataIsNull)
            {
                request.TaxDocumentMetadata = null;
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
        
        private Amazon.TaxSettings.Model.GetTaxRegistrationDocumentResponse CallAWSServiceOperation(IAmazonTaxSettings client, Amazon.TaxSettings.Model.GetTaxRegistrationDocumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Tax Settings", "GetTaxRegistrationDocument");
            try
            {
                #if DESKTOP
                return client.GetTaxRegistrationDocument(request);
                #elif CORECLR
                return client.GetTaxRegistrationDocumentAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationS3Location_Bucket { get; set; }
            public System.String DestinationS3Location_Prefix { get; set; }
            public System.String TaxDocumentMetadata_TaxDocumentAccessToken { get; set; }
            public System.String TaxDocumentMetadata_TaxDocumentName { get; set; }
            public System.Func<Amazon.TaxSettings.Model.GetTaxRegistrationDocumentResponse, GetTSATaxRegistrationDocumentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DestinationFilePath;
        }
        
    }
}
