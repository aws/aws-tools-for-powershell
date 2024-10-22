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
using Amazon.PcaConnectorScep;
using Amazon.PcaConnectorScep.Model;

namespace Amazon.PowerShell.Cmdlets.PCASCEP
{
    /// <summary>
    /// Retrieves the metadata for the specified <a href="https://docs.aws.amazon.com/C4SCEP_API/pca-connector-scep/latest/APIReference/API_Challenge.html">Challenge</a>.
    /// </summary>
    [Cmdlet("Get", "PCASCEPChallengeMetadata")]
    [OutputType("Amazon.PcaConnectorScep.Model.ChallengeMetadata")]
    [AWSCmdlet("Calls the Private CA Connector for SCEP GetChallengeMetadata API operation.", Operation = new[] {"GetChallengeMetadata"}, SelectReturnType = typeof(Amazon.PcaConnectorScep.Model.GetChallengeMetadataResponse))]
    [AWSCmdletOutput("Amazon.PcaConnectorScep.Model.ChallengeMetadata or Amazon.PcaConnectorScep.Model.GetChallengeMetadataResponse",
        "This cmdlet returns an Amazon.PcaConnectorScep.Model.ChallengeMetadata object.",
        "The service call response (type Amazon.PcaConnectorScep.Model.GetChallengeMetadataResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPCASCEPChallengeMetadataCmdlet : AmazonPcaConnectorScepClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChallengeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the challenge.</para>
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
        public System.String ChallengeArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChallengeMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PcaConnectorScep.Model.GetChallengeMetadataResponse).
        /// Specifying the name of a property of type Amazon.PcaConnectorScep.Model.GetChallengeMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChallengeMetadata";
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
                context.Select = CreateSelectDelegate<Amazon.PcaConnectorScep.Model.GetChallengeMetadataResponse, GetPCASCEPChallengeMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChallengeArn = this.ChallengeArn;
            #if MODULAR
            if (this.ChallengeArn == null && ParameterWasBound(nameof(this.ChallengeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChallengeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PcaConnectorScep.Model.GetChallengeMetadataRequest();
            
            if (cmdletContext.ChallengeArn != null)
            {
                request.ChallengeArn = cmdletContext.ChallengeArn;
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
        
        private Amazon.PcaConnectorScep.Model.GetChallengeMetadataResponse CallAWSServiceOperation(IAmazonPcaConnectorScep client, Amazon.PcaConnectorScep.Model.GetChallengeMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Private CA Connector for SCEP", "GetChallengeMetadata");
            try
            {
                #if DESKTOP
                return client.GetChallengeMetadata(request);
                #elif CORECLR
                return client.GetChallengeMetadataAsync(request).GetAwaiter().GetResult();
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
            public System.String ChallengeArn { get; set; }
            public System.Func<Amazon.PcaConnectorScep.Model.GetChallengeMetadataResponse, GetPCASCEPChallengeMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChallengeMetadata;
        }
        
    }
}
