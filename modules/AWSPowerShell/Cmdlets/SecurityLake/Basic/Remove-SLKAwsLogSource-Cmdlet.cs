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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Removes a natively supported Amazon Web Services service as an Amazon Security Lake
    /// source. You can remove a source for one or more Regions. When you remove the source,
    /// Security Lake stops collecting data from that source in the specified Regions and
    /// accounts, and subscribers can no longer consume new data from the source. However,
    /// subscribers can still consume data that Security Lake collected from the source before
    /// removal.
    /// 
    ///  
    /// <para>
    /// You can choose any source type in any Amazon Web Services Region for either accounts
    /// that are part of a trusted organization or standalone accounts. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SLKAwsLogSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse")]
    [AWSCmdlet("Calls the Amazon Security Lake DeleteAwsLogSource API operation.", Operation = new[] {"DeleteAwsLogSource"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse))]
    [AWSCmdletOutput("Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse",
        "This cmdlet returns an Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse object containing multiple properties."
    )]
    public partial class RemoveSLKAwsLogSourceCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>Specify the natively-supported Amazon Web Services service to remove as a source in
        /// Security Lake.</para>
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
        [Alias("Sources")]
        public Amazon.SecurityLake.Model.AwsLogSourceConfiguration[] Source { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Source), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SLKAwsLogSource (DeleteAwsLogSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse, RemoveSLKAwsLogSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Source != null)
            {
                context.Source = new List<Amazon.SecurityLake.Model.AwsLogSourceConfiguration>(this.Source);
            }
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityLake.Model.DeleteAwsLogSourceRequest();
            
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
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
        
        private Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.DeleteAwsLogSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "DeleteAwsLogSource");
            try
            {
                #if DESKTOP
                return client.DeleteAwsLogSource(request);
                #elif CORECLR
                return client.DeleteAwsLogSourceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityLake.Model.AwsLogSourceConfiguration> Source { get; set; }
            public System.Func<Amazon.SecurityLake.Model.DeleteAwsLogSourceResponse, RemoveSLKAwsLogSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
