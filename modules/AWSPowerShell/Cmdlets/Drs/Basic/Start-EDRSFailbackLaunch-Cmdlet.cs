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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Initiates a Job for launching the machine that is being failed back to from the specified
    /// Recovery Instance. This will run conversion on the failback client and will reboot
    /// your machine, thus completing the failback process.
    /// </summary>
    [Cmdlet("Start", "EDRSFailbackLaunch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Drs.Model.Job")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service StartFailbackLaunch API operation.", Operation = new[] {"StartFailbackLaunch"}, SelectReturnType = typeof(Amazon.Drs.Model.StartFailbackLaunchResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.Job or Amazon.Drs.Model.StartFailbackLaunchResponse",
        "This cmdlet returns an Amazon.Drs.Model.Job object.",
        "The service call response (type Amazon.Drs.Model.StartFailbackLaunchResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartEDRSFailbackLaunchCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RecoveryInstanceIDs
        /// <summary>
        /// <para>
        /// <para>The IDs of the Recovery Instance whose failback launch we want to request.</para>
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
        public System.String[] RecoveryInstanceIDs { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be associated with the failback launch Job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Job'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.StartFailbackLaunchResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.StartFailbackLaunchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Job";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EDRSFailbackLaunch (StartFailbackLaunch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.StartFailbackLaunchResponse, StartEDRSFailbackLaunchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.RecoveryInstanceIDs != null)
            {
                context.RecoveryInstanceIDs = new List<System.String>(this.RecoveryInstanceIDs);
            }
            #if MODULAR
            if (this.RecoveryInstanceIDs == null && ParameterWasBound(nameof(this.RecoveryInstanceIDs)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryInstanceIDs which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Drs.Model.StartFailbackLaunchRequest();
            
            if (cmdletContext.RecoveryInstanceIDs != null)
            {
                request.RecoveryInstanceIDs = cmdletContext.RecoveryInstanceIDs;
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
        
        private Amazon.Drs.Model.StartFailbackLaunchResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.StartFailbackLaunchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "StartFailbackLaunch");
            try
            {
                #if DESKTOP
                return client.StartFailbackLaunch(request);
                #elif CORECLR
                return client.StartFailbackLaunchAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> RecoveryInstanceIDs { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Drs.Model.StartFailbackLaunchResponse, StartEDRSFailbackLaunchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Job;
        }
        
    }
}
