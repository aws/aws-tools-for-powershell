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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Update a channel schedule
    /// </summary>
    [Cmdlet("Update", "EMLScheduleBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.BatchUpdateScheduleResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive BatchUpdateSchedule API operation.", Operation = new[] {"BatchUpdateSchedule"}, SelectReturnType = typeof(Amazon.MediaLive.Model.BatchUpdateScheduleResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.BatchUpdateScheduleResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.BatchUpdateScheduleResponse object containing multiple properties."
    )]
    public partial class UpdateEMLScheduleBatchCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Deletes_ActionName
        /// <summary>
        /// <para>
        /// A list of schedule actions to delete.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deletes_ActionNames")]
        public System.String[] Deletes_ActionName { get; set; }
        #endregion
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// Id of the channel whose schedule is being updated.
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
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter Creates_ScheduleAction
        /// <summary>
        /// <para>
        /// A list of schedule actions to create.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Creates_ScheduleActions")]
        public Amazon.MediaLive.Model.ScheduleAction[] Creates_ScheduleAction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.BatchUpdateScheduleResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.BatchUpdateScheduleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLScheduleBatch (BatchUpdateSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.BatchUpdateScheduleResponse, UpdateEMLScheduleBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelId = this.ChannelId;
            #if MODULAR
            if (this.ChannelId == null && ParameterWasBound(nameof(this.ChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Creates_ScheduleAction != null)
            {
                context.Creates_ScheduleAction = new List<Amazon.MediaLive.Model.ScheduleAction>(this.Creates_ScheduleAction);
            }
            if (this.Deletes_ActionName != null)
            {
                context.Deletes_ActionName = new List<System.String>(this.Deletes_ActionName);
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
            var request = new Amazon.MediaLive.Model.BatchUpdateScheduleRequest();
            
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            
             // populate Creates
            var requestCreatesIsNull = true;
            request.Creates = new Amazon.MediaLive.Model.BatchScheduleActionCreateRequest();
            List<Amazon.MediaLive.Model.ScheduleAction> requestCreates_creates_ScheduleAction = null;
            if (cmdletContext.Creates_ScheduleAction != null)
            {
                requestCreates_creates_ScheduleAction = cmdletContext.Creates_ScheduleAction;
            }
            if (requestCreates_creates_ScheduleAction != null)
            {
                request.Creates.ScheduleActions = requestCreates_creates_ScheduleAction;
                requestCreatesIsNull = false;
            }
             // determine if request.Creates should be set to null
            if (requestCreatesIsNull)
            {
                request.Creates = null;
            }
            
             // populate Deletes
            var requestDeletesIsNull = true;
            request.Deletes = new Amazon.MediaLive.Model.BatchScheduleActionDeleteRequest();
            List<System.String> requestDeletes_deletes_ActionName = null;
            if (cmdletContext.Deletes_ActionName != null)
            {
                requestDeletes_deletes_ActionName = cmdletContext.Deletes_ActionName;
            }
            if (requestDeletes_deletes_ActionName != null)
            {
                request.Deletes.ActionNames = requestDeletes_deletes_ActionName;
                requestDeletesIsNull = false;
            }
             // determine if request.Deletes should be set to null
            if (requestDeletesIsNull)
            {
                request.Deletes = null;
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
        
        private Amazon.MediaLive.Model.BatchUpdateScheduleResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.BatchUpdateScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "BatchUpdateSchedule");
            try
            {
                #if DESKTOP
                return client.BatchUpdateSchedule(request);
                #elif CORECLR
                return client.BatchUpdateScheduleAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelId { get; set; }
            public List<Amazon.MediaLive.Model.ScheduleAction> Creates_ScheduleAction { get; set; }
            public List<System.String> Deletes_ActionName { get; set; }
            public System.Func<Amazon.MediaLive.Model.BatchUpdateScheduleResponse, UpdateEMLScheduleBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
