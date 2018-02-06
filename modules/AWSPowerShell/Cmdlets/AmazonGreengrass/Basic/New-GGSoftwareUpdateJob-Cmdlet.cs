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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Creates an Iot Job that will trigger your Greengrass Cores to update the software
    /// they are running.
    /// </summary>
    [Cmdlet("New", "GGSoftwareUpdateJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateSoftwareUpdateJob API operation.", Operation = new[] {"CreateSoftwareUpdateJob"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGSoftwareUpdateJobCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// The client token used to request idempotent
        /// operations.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter S3UrlSignerRole
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3UrlSignerRole { get; set; }
        #endregion
        
        #region Parameter SoftwareToUpdate
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Greengrass.SoftwareToUpdate")]
        public Amazon.Greengrass.SoftwareToUpdate SoftwareToUpdate { get; set; }
        #endregion
        
        #region Parameter UpdateAgentLogLevel
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Greengrass.UpdateAgentLogLevel")]
        public Amazon.Greengrass.UpdateAgentLogLevel UpdateAgentLogLevel { get; set; }
        #endregion
        
        #region Parameter UpdateTarget
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UpdateTargets")]
        public System.String[] UpdateTarget { get; set; }
        #endregion
        
        #region Parameter UpdateTargetsArchitecture
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Greengrass.UpdateTargetsArchitecture")]
        public Amazon.Greengrass.UpdateTargetsArchitecture UpdateTargetsArchitecture { get; set; }
        #endregion
        
        #region Parameter UpdateTargetsOperatingSystem
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Greengrass.UpdateTargetsOperatingSystem")]
        public Amazon.Greengrass.UpdateTargetsOperatingSystem UpdateTargetsOperatingSystem { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGSoftwareUpdateJob (CreateSoftwareUpdateJob)"))
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
            
            context.AmznClientToken = this.AmznClientToken;
            context.S3UrlSignerRole = this.S3UrlSignerRole;
            context.SoftwareToUpdate = this.SoftwareToUpdate;
            context.UpdateAgentLogLevel = this.UpdateAgentLogLevel;
            if (this.UpdateTarget != null)
            {
                context.UpdateTargets = new List<System.String>(this.UpdateTarget);
            }
            context.UpdateTargetsArchitecture = this.UpdateTargetsArchitecture;
            context.UpdateTargetsOperatingSystem = this.UpdateTargetsOperatingSystem;
            
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
            var request = new Amazon.Greengrass.Model.CreateSoftwareUpdateJobRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            if (cmdletContext.S3UrlSignerRole != null)
            {
                request.S3UrlSignerRole = cmdletContext.S3UrlSignerRole;
            }
            if (cmdletContext.SoftwareToUpdate != null)
            {
                request.SoftwareToUpdate = cmdletContext.SoftwareToUpdate;
            }
            if (cmdletContext.UpdateAgentLogLevel != null)
            {
                request.UpdateAgentLogLevel = cmdletContext.UpdateAgentLogLevel;
            }
            if (cmdletContext.UpdateTargets != null)
            {
                request.UpdateTargets = cmdletContext.UpdateTargets;
            }
            if (cmdletContext.UpdateTargetsArchitecture != null)
            {
                request.UpdateTargetsArchitecture = cmdletContext.UpdateTargetsArchitecture;
            }
            if (cmdletContext.UpdateTargetsOperatingSystem != null)
            {
                request.UpdateTargetsOperatingSystem = cmdletContext.UpdateTargetsOperatingSystem;
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
        
        private Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateSoftwareUpdateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateSoftwareUpdateJob");
            try
            {
                #if DESKTOP
                return client.CreateSoftwareUpdateJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateSoftwareUpdateJobAsync(request);
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
            public System.String AmznClientToken { get; set; }
            public System.String S3UrlSignerRole { get; set; }
            public Amazon.Greengrass.SoftwareToUpdate SoftwareToUpdate { get; set; }
            public Amazon.Greengrass.UpdateAgentLogLevel UpdateAgentLogLevel { get; set; }
            public List<System.String> UpdateTargets { get; set; }
            public Amazon.Greengrass.UpdateTargetsArchitecture UpdateTargetsArchitecture { get; set; }
            public Amazon.Greengrass.UpdateTargetsOperatingSystem UpdateTargetsOperatingSystem { get; set; }
        }
        
    }
}
