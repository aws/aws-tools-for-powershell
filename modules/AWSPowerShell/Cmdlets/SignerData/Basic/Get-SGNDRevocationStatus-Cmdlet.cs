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
using Amazon.SignerData;
using Amazon.SignerData.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SGND
{
    /// <summary>
    /// Retrieves the revocation status for a signed artifact by checking if the signing profile,
    /// job, or certificate has been revoked.
    /// </summary>
    [Cmdlet("Get", "SGNDRevocationStatus")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Signer Data Plane GetRevocationStatus API operation.", Operation = new[] {"GetRevocationStatus"}, SelectReturnType = typeof(Amazon.SignerData.Model.GetRevocationStatusResponse))]
    [AWSCmdletOutput("System.String or Amazon.SignerData.Model.GetRevocationStatusResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.SignerData.Model.GetRevocationStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSGNDRevocationStatusCmdlet : AmazonSignerDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateHash
        /// <summary>
        /// <para>
        /// <para>List of certificate hashes to check for revocation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("CertificateHashes")]
        public System.String[] CertificateHash { get; set; }
        #endregion
        
        #region Parameter JobArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the signing job that produced the signature.</para>
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
        public System.String JobArn { get; set; }
        #endregion
        
        #region Parameter PlatformId
        /// <summary>
        /// <para>
        /// <para>The platform identifier for the signing platform used.</para>
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
        public System.String PlatformId { get; set; }
        #endregion
        
        #region Parameter ProfileVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the signing profile version used to sign the artifact.</para>
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
        public System.String ProfileVersionArn { get; set; }
        #endregion
        
        #region Parameter SignatureTimestamp
        /// <summary>
        /// <para>
        /// <para>The timestamp when the artifact was signed, in ISO 8601 format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? SignatureTimestamp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RevokedEntities'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SignerData.Model.GetRevocationStatusResponse).
        /// Specifying the name of a property of type Amazon.SignerData.Model.GetRevocationStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RevokedEntities";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SignerData.Model.GetRevocationStatusResponse, GetSGNDRevocationStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CertificateHash != null)
            {
                context.CertificateHash = new List<System.String>(this.CertificateHash);
            }
            #if MODULAR
            if (this.CertificateHash == null && ParameterWasBound(nameof(this.CertificateHash)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateHash which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobArn = this.JobArn;
            #if MODULAR
            if (this.JobArn == null && ParameterWasBound(nameof(this.JobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter JobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlatformId = this.PlatformId;
            #if MODULAR
            if (this.PlatformId == null && ParameterWasBound(nameof(this.PlatformId)))
            {
                WriteWarning("You are passing $null as a value for parameter PlatformId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProfileVersionArn = this.ProfileVersionArn;
            #if MODULAR
            if (this.ProfileVersionArn == null && ParameterWasBound(nameof(this.ProfileVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SignatureTimestamp = this.SignatureTimestamp;
            #if MODULAR
            if (this.SignatureTimestamp == null && ParameterWasBound(nameof(this.SignatureTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter SignatureTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SignerData.Model.GetRevocationStatusRequest();
            
            if (cmdletContext.CertificateHash != null)
            {
                request.CertificateHashes = cmdletContext.CertificateHash;
            }
            if (cmdletContext.JobArn != null)
            {
                request.JobArn = cmdletContext.JobArn;
            }
            if (cmdletContext.PlatformId != null)
            {
                request.PlatformId = cmdletContext.PlatformId;
            }
            if (cmdletContext.ProfileVersionArn != null)
            {
                request.ProfileVersionArn = cmdletContext.ProfileVersionArn;
            }
            if (cmdletContext.SignatureTimestamp != null)
            {
                request.SignatureTimestamp = cmdletContext.SignatureTimestamp.Value;
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
        
        private Amazon.SignerData.Model.GetRevocationStatusResponse CallAWSServiceOperation(IAmazonSignerData client, Amazon.SignerData.Model.GetRevocationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Signer Data Plane", "GetRevocationStatus");
            try
            {
                return client.GetRevocationStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CertificateHash { get; set; }
            public System.String JobArn { get; set; }
            public System.String PlatformId { get; set; }
            public System.String ProfileVersionArn { get; set; }
            public System.DateTime? SignatureTimestamp { get; set; }
            public System.Func<Amazon.SignerData.Model.GetRevocationStatusResponse, GetSGNDRevocationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RevokedEntities;
        }
        
    }
}
