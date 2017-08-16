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
    /// Creates a subscription definition. You may optionally provide the initial version
    /// of the subscription definition or use ``CreateSubscriptionDefinitionVersion`` at a
    /// later time.
    /// </summary>
    [Cmdlet("New", "GGSubscriptionDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateSubscriptionDefinitionResponse")]
    [AWSCmdlet("Invokes the CreateSubscriptionDefinition operation against AWS Greengrass.", Operation = new[] {"CreateSubscriptionDefinition"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateSubscriptionDefinitionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.CreateSubscriptionDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGSubscriptionDefinitionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// name of the subscription definition
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter InitialVersion_Subscription
        /// <summary>
        /// <para>
        /// Subscriptions in the version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InitialVersion_Subscriptions")]
        public Amazon.Greengrass.Model.Subscription[] InitialVersion_Subscription { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGSubscriptionDefinition (CreateSubscriptionDefinition)"))
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
            if (this.InitialVersion_Subscription != null)
            {
                context.InitialVersion_Subscriptions = new List<Amazon.Greengrass.Model.Subscription>(this.InitialVersion_Subscription);
            }
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
            var request = new Amazon.Greengrass.Model.CreateSubscriptionDefinitionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            
             // populate InitialVersion
            bool requestInitialVersionIsNull = true;
            request.InitialVersion = new Amazon.Greengrass.Model.SubscriptionDefinitionVersion();
            List<Amazon.Greengrass.Model.Subscription> requestInitialVersion_initialVersion_Subscription = null;
            if (cmdletContext.InitialVersion_Subscriptions != null)
            {
                requestInitialVersion_initialVersion_Subscription = cmdletContext.InitialVersion_Subscriptions;
            }
            if (requestInitialVersion_initialVersion_Subscription != null)
            {
                request.InitialVersion.Subscriptions = requestInitialVersion_initialVersion_Subscription;
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
        
        private Amazon.Greengrass.Model.CreateSubscriptionDefinitionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateSubscriptionDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateSubscriptionDefinition");
            try
            {
                #if DESKTOP
                return client.CreateSubscriptionDefinition(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateSubscriptionDefinitionAsync(request);
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
            public List<Amazon.Greengrass.Model.Subscription> InitialVersion_Subscriptions { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
