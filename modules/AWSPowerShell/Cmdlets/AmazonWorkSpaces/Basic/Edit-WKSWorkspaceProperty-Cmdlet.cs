/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Modifies the WorkSpace properties, including the running mode and AutoStop time.
    /// </summary>
    [Cmdlet("Edit", "WKSWorkspaceProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyWorkspaceProperties operation against Amazon WorkSpaces.", Operation = new[] {"ModifyWorkspaceProperties"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the WorkspaceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditWKSWorkspacePropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter WorkspaceProperties_RunningMode
        /// <summary>
        /// <para>
        /// <para>The running mode of the WorkSpace. AlwaysOn WorkSpaces are billed monthly. AutoStop
        /// WorkSpaces are billed by the hour and stopped when no longer being used in order to
        /// save on costs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WorkSpaces.RunningMode")]
        public Amazon.WorkSpaces.RunningMode WorkspaceProperties_RunningMode { get; set; }
        #endregion
        
        #region Parameter WorkspaceProperties_RunningModeAutoStopTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The time after a user logs off when WorkSpaces are automatically stopped. Configured
        /// in 60 minute intervals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WorkspaceProperties_RunningModeAutoStopTimeoutInMinutes")]
        public System.Int32 WorkspaceProperties_RunningModeAutoStopTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the WorkspaceId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("WorkspaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSWorkspaceProperty (ModifyWorkspaceProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.WorkspaceId = this.WorkspaceId;
            context.WorkspaceProperties_RunningMode = this.WorkspaceProperties_RunningMode;
            if (ParameterWasBound("WorkspaceProperties_RunningModeAutoStopTimeoutInMinute"))
                context.WorkspaceProperties_RunningModeAutoStopTimeoutInMinutes = this.WorkspaceProperties_RunningModeAutoStopTimeoutInMinute;
            
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
            var request = new Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesRequest();
            
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
            }
            
             // populate WorkspaceProperties
            bool requestWorkspacePropertiesIsNull = true;
            request.WorkspaceProperties = new Amazon.WorkSpaces.Model.WorkspaceProperties();
            Amazon.WorkSpaces.RunningMode requestWorkspaceProperties_workspaceProperties_RunningMode = null;
            if (cmdletContext.WorkspaceProperties_RunningMode != null)
            {
                requestWorkspaceProperties_workspaceProperties_RunningMode = cmdletContext.WorkspaceProperties_RunningMode;
            }
            if (requestWorkspaceProperties_workspaceProperties_RunningMode != null)
            {
                request.WorkspaceProperties.RunningMode = requestWorkspaceProperties_workspaceProperties_RunningMode;
                requestWorkspacePropertiesIsNull = false;
            }
            System.Int32? requestWorkspaceProperties_workspaceProperties_RunningModeAutoStopTimeoutInMinute = null;
            if (cmdletContext.WorkspaceProperties_RunningModeAutoStopTimeoutInMinutes != null)
            {
                requestWorkspaceProperties_workspaceProperties_RunningModeAutoStopTimeoutInMinute = cmdletContext.WorkspaceProperties_RunningModeAutoStopTimeoutInMinutes.Value;
            }
            if (requestWorkspaceProperties_workspaceProperties_RunningModeAutoStopTimeoutInMinute != null)
            {
                request.WorkspaceProperties.RunningModeAutoStopTimeoutInMinutes = requestWorkspaceProperties_workspaceProperties_RunningModeAutoStopTimeoutInMinute.Value;
                requestWorkspacePropertiesIsNull = false;
            }
             // determine if request.WorkspaceProperties should be set to null
            if (requestWorkspacePropertiesIsNull)
            {
                request.WorkspaceProperties = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.WorkspaceId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifyWorkspaceProperties");
            #if DESKTOP
            return client.ModifyWorkspaceProperties(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ModifyWorkspacePropertiesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String WorkspaceId { get; set; }
            public Amazon.WorkSpaces.RunningMode WorkspaceProperties_RunningMode { get; set; }
            public System.Int32? WorkspaceProperties_RunningModeAutoStopTimeoutInMinutes { get; set; }
        }
        
    }
}
