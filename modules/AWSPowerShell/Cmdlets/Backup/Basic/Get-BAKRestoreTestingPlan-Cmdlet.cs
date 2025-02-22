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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Returns <c>RestoreTestingPlan</c> details for the specified <c>RestoreTestingPlanName</c>.
    /// The details are the body of a restore testing plan in JSON format, in addition to
    /// plan metadata.
    /// </summary>
    [Cmdlet("Get", "BAKRestoreTestingPlan")]
    [OutputType("Amazon.Backup.Model.RestoreTestingPlanForGet")]
    [AWSCmdlet("Calls the AWS Backup GetRestoreTestingPlan API operation.", Operation = new[] {"GetRestoreTestingPlan"}, SelectReturnType = typeof(Amazon.Backup.Model.GetRestoreTestingPlanResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.RestoreTestingPlanForGet or Amazon.Backup.Model.GetRestoreTestingPlanResponse",
        "This cmdlet returns an Amazon.Backup.Model.RestoreTestingPlanForGet object.",
        "The service call response (type Amazon.Backup.Model.GetRestoreTestingPlanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBAKRestoreTestingPlanCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RestoreTestingPlanName
        /// <summary>
        /// <para>
        /// <para>Required unique name of the restore testing plan.</para>
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
        public System.String RestoreTestingPlanName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RestoreTestingPlan'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.GetRestoreTestingPlanResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.GetRestoreTestingPlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RestoreTestingPlan";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RestoreTestingPlanName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RestoreTestingPlanName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RestoreTestingPlanName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.GetRestoreTestingPlanResponse, GetBAKRestoreTestingPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RestoreTestingPlanName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RestoreTestingPlanName = this.RestoreTestingPlanName;
            #if MODULAR
            if (this.RestoreTestingPlanName == null && ParameterWasBound(nameof(this.RestoreTestingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.GetRestoreTestingPlanRequest();
            
            if (cmdletContext.RestoreTestingPlanName != null)
            {
                request.RestoreTestingPlanName = cmdletContext.RestoreTestingPlanName;
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
        
        private Amazon.Backup.Model.GetRestoreTestingPlanResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.GetRestoreTestingPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "GetRestoreTestingPlan");
            try
            {
                #if DESKTOP
                return client.GetRestoreTestingPlan(request);
                #elif CORECLR
                return client.GetRestoreTestingPlanAsync(request).GetAwaiter().GetResult();
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
            public System.String RestoreTestingPlanName { get; set; }
            public System.Func<Amazon.Backup.Model.GetRestoreTestingPlanResponse, GetBAKRestoreTestingPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RestoreTestingPlan;
        }
        
    }
}
