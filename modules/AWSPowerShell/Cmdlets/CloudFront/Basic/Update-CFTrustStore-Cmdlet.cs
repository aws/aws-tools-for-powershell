/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Updates a trust store.
    /// </summary>
    [Cmdlet("Update", "CFTrustStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.TrustStore")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateTrustStore API operation.", Operation = new[] {"UpdateTrustStore"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateTrustStoreResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.TrustStore or Amazon.CloudFront.Model.UpdateTrustStoreResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.TrustStore object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateTrustStoreResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFTrustStoreCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CaCertificatesBundleS3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CaCertificatesBundleSource_CaCertificatesBundleS3Location_Bucket")]
        public System.String CaCertificatesBundleS3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The trust store ID.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The current version (<c>ETag</c> value) of the trust store you are updating.</para>
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
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter CaCertificatesBundleS3Location_Key
        /// <summary>
        /// <para>
        /// <para>The location's key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CaCertificatesBundleSource_CaCertificatesBundleS3Location_Key")]
        public System.String CaCertificatesBundleS3Location_Key { get; set; }
        #endregion
        
        #region Parameter CaCertificatesBundleS3Location_Region
        /// <summary>
        /// <para>
        /// <para>The location's Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CaCertificatesBundleSource_CaCertificatesBundleS3Location_Region")]
        public System.String CaCertificatesBundleS3Location_Region { get; set; }
        #endregion
        
        #region Parameter CaCertificatesBundleS3Location_Version
        /// <summary>
        /// <para>
        /// <para>The location's version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CaCertificatesBundleSource_CaCertificatesBundleS3Location_Version")]
        public System.String CaCertificatesBundleS3Location_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrustStore'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateTrustStoreResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateTrustStoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrustStore";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFTrustStore (UpdateTrustStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateTrustStoreResponse, UpdateCFTrustStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CaCertificatesBundleS3Location_Bucket = this.CaCertificatesBundleS3Location_Bucket;
            context.CaCertificatesBundleS3Location_Key = this.CaCertificatesBundleS3Location_Key;
            context.CaCertificatesBundleS3Location_Region = this.CaCertificatesBundleS3Location_Region;
            context.CaCertificatesBundleS3Location_Version = this.CaCertificatesBundleS3Location_Version;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            #if MODULAR
            if (this.IfMatch == null && ParameterWasBound(nameof(this.IfMatch)))
            {
                WriteWarning("You are passing $null as a value for parameter IfMatch which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFront.Model.UpdateTrustStoreRequest();
            
            
             // populate CaCertificatesBundleSource
            var requestCaCertificatesBundleSourceIsNull = true;
            request.CaCertificatesBundleSource = new Amazon.CloudFront.Model.CaCertificatesBundleSource();
            Amazon.CloudFront.Model.CaCertificatesBundleS3Location requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location = null;
            
             // populate CaCertificatesBundleS3Location
            var requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3LocationIsNull = true;
            requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location = new Amazon.CloudFront.Model.CaCertificatesBundleS3Location();
            System.String requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Bucket = null;
            if (cmdletContext.CaCertificatesBundleS3Location_Bucket != null)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Bucket = cmdletContext.CaCertificatesBundleS3Location_Bucket;
            }
            if (requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Bucket != null)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location.Bucket = requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Bucket;
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3LocationIsNull = false;
            }
            System.String requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Key = null;
            if (cmdletContext.CaCertificatesBundleS3Location_Key != null)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Key = cmdletContext.CaCertificatesBundleS3Location_Key;
            }
            if (requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Key != null)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location.Key = requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Key;
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3LocationIsNull = false;
            }
            System.String requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Region = null;
            if (cmdletContext.CaCertificatesBundleS3Location_Region != null)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Region = cmdletContext.CaCertificatesBundleS3Location_Region;
            }
            if (requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Region != null)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location.Region = requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Region;
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3LocationIsNull = false;
            }
            System.String requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Version = null;
            if (cmdletContext.CaCertificatesBundleS3Location_Version != null)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Version = cmdletContext.CaCertificatesBundleS3Location_Version;
            }
            if (requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Version != null)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location.Version = requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location_caCertificatesBundleS3Location_Version;
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3LocationIsNull = false;
            }
             // determine if requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location should be set to null
            if (requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3LocationIsNull)
            {
                requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location = null;
            }
            if (requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location != null)
            {
                request.CaCertificatesBundleSource.CaCertificatesBundleS3Location = requestCaCertificatesBundleSource_caCertificatesBundleSource_CaCertificatesBundleS3Location;
                requestCaCertificatesBundleSourceIsNull = false;
            }
             // determine if request.CaCertificatesBundleSource should be set to null
            if (requestCaCertificatesBundleSourceIsNull)
            {
                request.CaCertificatesBundleSource = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
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
        
        private Amazon.CloudFront.Model.UpdateTrustStoreResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateTrustStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateTrustStore");
            try
            {
                return client.UpdateTrustStoreAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CaCertificatesBundleS3Location_Bucket { get; set; }
            public System.String CaCertificatesBundleS3Location_Key { get; set; }
            public System.String CaCertificatesBundleS3Location_Region { get; set; }
            public System.String CaCertificatesBundleS3Location_Version { get; set; }
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateTrustStoreResponse, UpdateCFTrustStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrustStore;
        }
        
    }
}
