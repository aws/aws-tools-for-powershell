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
    /// Input the Restore Testing Plan name and Restore Testing Selection name.
    /// 
    ///  
    /// <para>
    /// All testing selections associated with a restore testing plan must be deleted before
    /// the restore testing plan can be deleted.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "BAKRestoreTestingSelection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Backup DeleteRestoreTestingSelection API operation.", Operation = new[] {"DeleteRestoreTestingSelection"}, SelectReturnType = typeof(Amazon.Backup.Model.DeleteRestoreTestingSelectionResponse))]
    [AWSCmdletOutput("None or Amazon.Backup.Model.DeleteRestoreTestingSelectionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Backup.Model.DeleteRestoreTestingSelectionResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveBAKRestoreTestingSelectionCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RestoreTestingPlanName
        /// <summary>
        /// <para>
        /// <para>Required unique name of the restore testing plan that contains the restore testing
        /// selection you wish to delete.</para>
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
        public System.String RestoreTestingPlanName { get; set; }
        #endregion
        
        #region Parameter RestoreTestingSelectionName
        /// <summary>
        /// <para>
        /// <para>Required unique name of the restore testing selection you wish to delete.</para>
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
        public System.String RestoreTestingSelectionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.DeleteRestoreTestingSelectionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RestoreTestingSelectionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-BAKRestoreTestingSelection (DeleteRestoreTestingSelection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.DeleteRestoreTestingSelectionResponse, RemoveBAKRestoreTestingSelectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RestoreTestingPlanName = this.RestoreTestingPlanName;
            #if MODULAR
            if (this.RestoreTestingPlanName == null && ParameterWasBound(nameof(this.RestoreTestingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RestoreTestingSelectionName = this.RestoreTestingSelectionName;
            #if MODULAR
            if (this.RestoreTestingSelectionName == null && ParameterWasBound(nameof(this.RestoreTestingSelectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingSelectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.DeleteRestoreTestingSelectionRequest();
            
            if (cmdletContext.RestoreTestingPlanName != null)
            {
                request.RestoreTestingPlanName = cmdletContext.RestoreTestingPlanName;
            }
            if (cmdletContext.RestoreTestingSelectionName != null)
            {
                request.RestoreTestingSelectionName = cmdletContext.RestoreTestingSelectionName;
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
        
        private Amazon.Backup.Model.DeleteRestoreTestingSelectionResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.DeleteRestoreTestingSelectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "DeleteRestoreTestingSelection");
            try
            {
                #if DESKTOP
                return client.DeleteRestoreTestingSelection(request);
                #elif CORECLR
                return client.DeleteRestoreTestingSelectionAsync(request).GetAwaiter().GetResult();
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
            public System.String RestoreTestingSelectionName { get; set; }
            public System.Func<Amazon.Backup.Model.DeleteRestoreTestingSelectionResponse, RemoveBAKRestoreTestingSelectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
