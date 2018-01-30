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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Create an input
    /// </summary>
    [Cmdlet("New", "EMLInput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Input")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateInput API operation.", Operation = new[] {"CreateInput"})]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Input",
        "This cmdlet returns a Input object.",
        "The service call response (type Amazon.MediaLive.Model.CreateInputResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMLInputCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// Destination settings for PUSH type inputs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destinations")]
        public Amazon.MediaLive.Model.InputDestinationRequest[] Destination { get; set; }
        #endregion
        
        #region Parameter InputSecurityGroup
        /// <summary>
        /// <para>
        /// A list of security groups referenced
        /// by IDs to attach to the input.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputSecurityGroups")]
        public System.String[] InputSecurityGroup { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Name of the input.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// Unique identifier of the request to ensure the
        /// request is handledexactly once in case of retries.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// The source URLs for a PULL-type input. Every PULL
        /// type input needsexactly two source URLs for redundancy.Only specify sources for PULL
        /// type Inputs. Leave Destinations empty.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Sources")]
        public Amazon.MediaLive.Model.InputSourceRequest[] Source { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaLive.InputType")]
        public Amazon.MediaLive.InputType Type { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLInput (CreateInput)"))
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
            
            if (this.Destination != null)
            {
                context.Destinations = new List<Amazon.MediaLive.Model.InputDestinationRequest>(this.Destination);
            }
            if (this.InputSecurityGroup != null)
            {
                context.InputSecurityGroups = new List<System.String>(this.InputSecurityGroup);
            }
            context.Name = this.Name;
            context.RequestId = this.RequestId;
            if (this.Source != null)
            {
                context.Sources = new List<Amazon.MediaLive.Model.InputSourceRequest>(this.Source);
            }
            context.Type = this.Type;
            
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
            var request = new Amazon.MediaLive.Model.CreateInputRequest();
            
            if (cmdletContext.Destinations != null)
            {
                request.Destinations = cmdletContext.Destinations;
            }
            if (cmdletContext.InputSecurityGroups != null)
            {
                request.InputSecurityGroups = cmdletContext.InputSecurityGroups;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            if (cmdletContext.Sources != null)
            {
                request.Sources = cmdletContext.Sources;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Input;
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
        
        private Amazon.MediaLive.Model.CreateInputResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.CreateInputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "CreateInput");
            try
            {
                #if DESKTOP
                return client.CreateInput(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateInputAsync(request);
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
            public List<Amazon.MediaLive.Model.InputDestinationRequest> Destinations { get; set; }
            public List<System.String> InputSecurityGroups { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            public List<Amazon.MediaLive.Model.InputSourceRequest> Sources { get; set; }
            public Amazon.MediaLive.InputType Type { get; set; }
        }
        
    }
}
