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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Gets the public endorsement key associated with the Nitro Trusted Platform Module
    /// (NitroTPM) for the specified instance.
    /// </summary>
    [Cmdlet("Get", "EC2InstanceTpmEkPub")]
    [OutputType("Amazon.EC2.Model.GetInstanceTpmEkPubResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetInstanceTpmEkPub API operation.", Operation = new[] {"GetInstanceTpmEkPub"}, SelectReturnType = typeof(Amazon.EC2.Model.GetInstanceTpmEkPubResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.GetInstanceTpmEkPubResponse",
        "This cmdlet returns an Amazon.EC2.Model.GetInstanceTpmEkPubResponse object containing multiple properties."
    )]
    public partial class GetEC2InstanceTpmEkPubCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance for which to get the public endorsement key.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter KeyFormat
        /// <summary>
        /// <para>
        /// <para>The required public endorsement key format. Specify <c>der</c> for a DER-encoded public
        /// key that is compatible with OpenSSL. Specify <c>tpmt</c> for a TPM 2.0 format that
        /// is compatible with tpm2-tools. The returned key is base64 encoded.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.EkPubKeyFormat")]
        public Amazon.EC2.EkPubKeyFormat KeyFormat { get; set; }
        #endregion
        
        #region Parameter KeyType
        /// <summary>
        /// <para>
        /// <para>The required public endorsement key type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.EkPubKeyType")]
        public Amazon.EC2.EkPubKeyType KeyType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetInstanceTpmEkPubResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetInstanceTpmEkPubResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetInstanceTpmEkPubResponse, GetEC2InstanceTpmEkPubCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyFormat = this.KeyFormat;
            #if MODULAR
            if (this.KeyFormat == null && ParameterWasBound(nameof(this.KeyFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyType = this.KeyType;
            #if MODULAR
            if (this.KeyType == null && ParameterWasBound(nameof(this.KeyType)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.GetInstanceTpmEkPubRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.KeyFormat != null)
            {
                request.KeyFormat = cmdletContext.KeyFormat;
            }
            if (cmdletContext.KeyType != null)
            {
                request.KeyType = cmdletContext.KeyType;
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
        
        private Amazon.EC2.Model.GetInstanceTpmEkPubResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetInstanceTpmEkPubRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetInstanceTpmEkPub");
            try
            {
                #if DESKTOP
                return client.GetInstanceTpmEkPub(request);
                #elif CORECLR
                return client.GetInstanceTpmEkPubAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public Amazon.EC2.EkPubKeyFormat KeyFormat { get; set; }
            public Amazon.EC2.EkPubKeyType KeyType { get; set; }
            public System.Func<Amazon.EC2.Model.GetInstanceTpmEkPubResponse, GetEC2InstanceTpmEkPubCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
