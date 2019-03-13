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
    /// Creates a version of a group which has already been defined.
    /// </summary>
    [Cmdlet("New", "GGGroupVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateGroupVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateGroupVersion API operation.", Operation = new[] {"CreateGroupVersion"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateGroupVersionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.CreateGroupVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGGroupVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter ConnectorDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the connector
        /// definition version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectorDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter CoreDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the core definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CoreDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter DeviceDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the device definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeviceDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter FunctionDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the function definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FunctionDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// The ID of the Greengrass group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter LoggerDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the logger definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LoggerDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter ResourceDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the resource definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter SubscriptionDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the subscription
        /// definition version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SubscriptionDefinitionVersionArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GroupId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGGroupVersion (CreateGroupVersion)"))
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
            context.ConnectorDefinitionVersionArn = this.ConnectorDefinitionVersionArn;
            context.CoreDefinitionVersionArn = this.CoreDefinitionVersionArn;
            context.DeviceDefinitionVersionArn = this.DeviceDefinitionVersionArn;
            context.FunctionDefinitionVersionArn = this.FunctionDefinitionVersionArn;
            context.GroupId = this.GroupId;
            context.LoggerDefinitionVersionArn = this.LoggerDefinitionVersionArn;
            context.ResourceDefinitionVersionArn = this.ResourceDefinitionVersionArn;
            context.SubscriptionDefinitionVersionArn = this.SubscriptionDefinitionVersionArn;
            
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
            var request = new Amazon.Greengrass.Model.CreateGroupVersionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            if (cmdletContext.ConnectorDefinitionVersionArn != null)
            {
                request.ConnectorDefinitionVersionArn = cmdletContext.ConnectorDefinitionVersionArn;
            }
            if (cmdletContext.CoreDefinitionVersionArn != null)
            {
                request.CoreDefinitionVersionArn = cmdletContext.CoreDefinitionVersionArn;
            }
            if (cmdletContext.DeviceDefinitionVersionArn != null)
            {
                request.DeviceDefinitionVersionArn = cmdletContext.DeviceDefinitionVersionArn;
            }
            if (cmdletContext.FunctionDefinitionVersionArn != null)
            {
                request.FunctionDefinitionVersionArn = cmdletContext.FunctionDefinitionVersionArn;
            }
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.LoggerDefinitionVersionArn != null)
            {
                request.LoggerDefinitionVersionArn = cmdletContext.LoggerDefinitionVersionArn;
            }
            if (cmdletContext.ResourceDefinitionVersionArn != null)
            {
                request.ResourceDefinitionVersionArn = cmdletContext.ResourceDefinitionVersionArn;
            }
            if (cmdletContext.SubscriptionDefinitionVersionArn != null)
            {
                request.SubscriptionDefinitionVersionArn = cmdletContext.SubscriptionDefinitionVersionArn;
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
        
        private Amazon.Greengrass.Model.CreateGroupVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateGroupVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateGroupVersion");
            try
            {
                #if DESKTOP
                return client.CreateGroupVersion(request);
                #elif CORECLR
                return client.CreateGroupVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectorDefinitionVersionArn { get; set; }
            public System.String CoreDefinitionVersionArn { get; set; }
            public System.String DeviceDefinitionVersionArn { get; set; }
            public System.String FunctionDefinitionVersionArn { get; set; }
            public System.String GroupId { get; set; }
            public System.String LoggerDefinitionVersionArn { get; set; }
            public System.String ResourceDefinitionVersionArn { get; set; }
            public System.String SubscriptionDefinitionVersionArn { get; set; }
        }
        
    }
}
