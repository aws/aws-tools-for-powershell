/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates an AWS IoT OTAUpdate on a target group of things or groups.
    /// </summary>
    [Cmdlet("New", "IOTOTAUpdate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateOTAUpdateResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateOTAUpdate API operation.", Operation = new[] {"CreateOTAUpdate"})]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateOTAUpdateResponse",
        "This cmdlet returns a Amazon.IoT.Model.CreateOTAUpdateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTOTAUpdateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalParameter
        /// <summary>
        /// <para>
        /// <para>A list of additional OTA update parameters which are name-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AdditionalParameters")]
        public System.Collections.Hashtable AdditionalParameter { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the OTA update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter File
        /// <summary>
        /// <para>
        /// <para>The files to be streamed by the OTA update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Files")]
        public Amazon.IoT.Model.OTAUpdateFile[] File { get; set; }
        #endregion
        
        #region Parameter OtaUpdateId
        /// <summary>
        /// <para>
        /// <para>The ID of the OTA update to be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String OtaUpdateId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that allows access to the AWS IoT Jobs service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targeted devices to receive OTA updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Targets")]
        public System.String[] Target { get; set; }
        #endregion
        
        #region Parameter TargetSelection
        /// <summary>
        /// <para>
        /// <para>Specifies whether the update will continue to run (CONTINUOUS), or will be complete
        /// after all the things specified as targets have completed the update (SNAPSHOT). If
        /// continuous, the update may also be run on a thing when a change is detected in a target.
        /// For example, an update will run on a thing when the thing is added to a target group,
        /// even after the update was completed by all things originally in the group. Valid values:
        /// CONTINUOUS | SNAPSHOT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.TargetSelection")]
        public Amazon.IoT.TargetSelection TargetSelection { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("OtaUpdateId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTOTAUpdate (CreateOTAUpdate)"))
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
            
            if (this.AdditionalParameter != null)
            {
                context.AdditionalParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalParameter.Keys)
                {
                    context.AdditionalParameters.Add((String)hashKey, (String)(this.AdditionalParameter[hashKey]));
                }
            }
            context.Description = this.Description;
            if (this.File != null)
            {
                context.Files = new List<Amazon.IoT.Model.OTAUpdateFile>(this.File);
            }
            context.OtaUpdateId = this.OtaUpdateId;
            context.RoleArn = this.RoleArn;
            if (this.Target != null)
            {
                context.Targets = new List<System.String>(this.Target);
            }
            context.TargetSelection = this.TargetSelection;
            
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
            var request = new Amazon.IoT.Model.CreateOTAUpdateRequest();
            
            if (cmdletContext.AdditionalParameters != null)
            {
                request.AdditionalParameters = cmdletContext.AdditionalParameters;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Files != null)
            {
                request.Files = cmdletContext.Files;
            }
            if (cmdletContext.OtaUpdateId != null)
            {
                request.OtaUpdateId = cmdletContext.OtaUpdateId;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Targets != null)
            {
                request.Targets = cmdletContext.Targets;
            }
            if (cmdletContext.TargetSelection != null)
            {
                request.TargetSelection = cmdletContext.TargetSelection;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.IoT.Model.CreateOTAUpdateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateOTAUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateOTAUpdate");
            try
            {
                #if DESKTOP
                return client.CreateOTAUpdate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateOTAUpdateAsync(request);
                return task.Result;
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
            public Dictionary<System.String, System.String> AdditionalParameters { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.IoT.Model.OTAUpdateFile> Files { get; set; }
            public System.String OtaUpdateId { get; set; }
            public System.String RoleArn { get; set; }
            public List<System.String> Targets { get; set; }
            public Amazon.IoT.TargetSelection TargetSelection { get; set; }
        }
        
    }
}
