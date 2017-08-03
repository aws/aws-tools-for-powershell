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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Creates a group. You may optionally provide the initial version of the group or use
    /// ''CreateGroupVersion'' at a later time.
    /// </summary>
    [Cmdlet("New", "GGGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateGroupResponse")]
    [AWSCmdlet("Invokes the CreateGroup operation against AWS Greengrass.", Operation = new[] {"CreateGroup"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateGroupResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.CreateGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGGroupCmdlet : AmazonGreengrassClientCmdlet, IExecutor
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
        
        #region Parameter InitialVersion_CoreDefinitionVersionArn
        /// <summary>
        /// <para>
        /// Core definition version arn for
        /// this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InitialVersion_CoreDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter InitialVersion_DeviceDefinitionVersionArn
        /// <summary>
        /// <para>
        /// Device definition version arn
        /// for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InitialVersion_DeviceDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter InitialVersion_FunctionDefinitionVersionArn
        /// <summary>
        /// <para>
        /// Function definition version
        /// arn for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InitialVersion_FunctionDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter InitialVersion_LoggerDefinitionVersionArn
        /// <summary>
        /// <para>
        /// Logger definitionv ersion arn
        /// for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InitialVersion_LoggerDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// name of the group
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter InitialVersion_SubscriptionDefinitionVersionArn
        /// <summary>
        /// <para>
        /// Subscription definition
        /// version arn for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InitialVersion_SubscriptionDefinitionVersionArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGGroup (CreateGroup)"))
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
            context.InitialVersion_CoreDefinitionVersionArn = this.InitialVersion_CoreDefinitionVersionArn;
            context.InitialVersion_DeviceDefinitionVersionArn = this.InitialVersion_DeviceDefinitionVersionArn;
            context.InitialVersion_FunctionDefinitionVersionArn = this.InitialVersion_FunctionDefinitionVersionArn;
            context.InitialVersion_LoggerDefinitionVersionArn = this.InitialVersion_LoggerDefinitionVersionArn;
            context.InitialVersion_SubscriptionDefinitionVersionArn = this.InitialVersion_SubscriptionDefinitionVersionArn;
            context.Name = this.Name;
            
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
            var request = new Amazon.Greengrass.Model.CreateGroupRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            
             // populate InitialVersion
            bool requestInitialVersionIsNull = true;
            request.InitialVersion = new Amazon.Greengrass.Model.GroupVersion();
            System.String requestInitialVersion_initialVersion_CoreDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_CoreDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_CoreDefinitionVersionArn = cmdletContext.InitialVersion_CoreDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_CoreDefinitionVersionArn != null)
            {
                request.InitialVersion.CoreDefinitionVersionArn = requestInitialVersion_initialVersion_CoreDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_DeviceDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_DeviceDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_DeviceDefinitionVersionArn = cmdletContext.InitialVersion_DeviceDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_DeviceDefinitionVersionArn != null)
            {
                request.InitialVersion.DeviceDefinitionVersionArn = requestInitialVersion_initialVersion_DeviceDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_FunctionDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_FunctionDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_FunctionDefinitionVersionArn = cmdletContext.InitialVersion_FunctionDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_FunctionDefinitionVersionArn != null)
            {
                request.InitialVersion.FunctionDefinitionVersionArn = requestInitialVersion_initialVersion_FunctionDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_LoggerDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_LoggerDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_LoggerDefinitionVersionArn = cmdletContext.InitialVersion_LoggerDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_LoggerDefinitionVersionArn != null)
            {
                request.InitialVersion.LoggerDefinitionVersionArn = requestInitialVersion_initialVersion_LoggerDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_SubscriptionDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_SubscriptionDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_SubscriptionDefinitionVersionArn = cmdletContext.InitialVersion_SubscriptionDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_SubscriptionDefinitionVersionArn != null)
            {
                request.InitialVersion.SubscriptionDefinitionVersionArn = requestInitialVersion_initialVersion_SubscriptionDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
             // determine if request.InitialVersion should be set to null
            if (requestInitialVersionIsNull)
            {
                request.InitialVersion = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Greengrass.Model.CreateGroupResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateGroup");
            #if DESKTOP
            return client.CreateGroup(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateGroupAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AmznClientToken { get; set; }
            public System.String InitialVersion_CoreDefinitionVersionArn { get; set; }
            public System.String InitialVersion_DeviceDefinitionVersionArn { get; set; }
            public System.String InitialVersion_FunctionDefinitionVersionArn { get; set; }
            public System.String InitialVersion_LoggerDefinitionVersionArn { get; set; }
            public System.String InitialVersion_SubscriptionDefinitionVersionArn { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
