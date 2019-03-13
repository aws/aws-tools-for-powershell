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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Used to remove the attributes for an app
    /// </summary>
    [Cmdlet("Remove", "PINAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Pinpoint.Model.AttributesResource")]
    [AWSCmdlet("Calls the Amazon Pinpoint RemoveAttributes API operation.", Operation = new[] {"RemoveAttributes"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.AttributesResource",
        "This cmdlet returns a AttributesResource object.",
        "The service call response (type Amazon.Pinpoint.Model.RemoveAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemovePINAttributeCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// The unique ID of your Amazon Pinpoint application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AttributeType
        /// <summary>
        /// <para>
        /// Type of attribute. Can be endpoint-custom-attributes,
        /// endpoint-custom-metrics, endpoint-user-attributes.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AttributeType { get; set; }
        #endregion
        
        #region Parameter UpdateAttributesRequest_Blacklist
        /// <summary>
        /// <para>
        /// The GLOB wildcard for removing the attributes
        /// in the application
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] UpdateAttributesRequest_Blacklist { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-PINAttribute (RemoveAttributes)"))
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
            
            context.ApplicationId = this.ApplicationId;
            context.AttributeType = this.AttributeType;
            if (this.UpdateAttributesRequest_Blacklist != null)
            {
                context.UpdateAttributesRequest_Blacklist = new List<System.String>(this.UpdateAttributesRequest_Blacklist);
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
            var request = new Amazon.Pinpoint.Model.RemoveAttributesRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.AttributeType != null)
            {
                request.AttributeType = cmdletContext.AttributeType;
            }
            
             // populate UpdateAttributesRequest
            bool requestUpdateAttributesRequestIsNull = true;
            request.UpdateAttributesRequest = new Amazon.Pinpoint.Model.UpdateAttributesRequest();
            List<System.String> requestUpdateAttributesRequest_updateAttributesRequest_Blacklist = null;
            if (cmdletContext.UpdateAttributesRequest_Blacklist != null)
            {
                requestUpdateAttributesRequest_updateAttributesRequest_Blacklist = cmdletContext.UpdateAttributesRequest_Blacklist;
            }
            if (requestUpdateAttributesRequest_updateAttributesRequest_Blacklist != null)
            {
                request.UpdateAttributesRequest.Blacklist = requestUpdateAttributesRequest_updateAttributesRequest_Blacklist;
                requestUpdateAttributesRequestIsNull = false;
            }
             // determine if request.UpdateAttributesRequest should be set to null
            if (requestUpdateAttributesRequestIsNull)
            {
                request.UpdateAttributesRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AttributesResource;
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
        
        private Amazon.Pinpoint.Model.RemoveAttributesResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.RemoveAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "RemoveAttributes");
            try
            {
                #if DESKTOP
                return client.RemoveAttributes(request);
                #elif CORECLR
                return client.RemoveAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String AttributeType { get; set; }
            public List<System.String> UpdateAttributesRequest_Blacklist { get; set; }
        }
        
    }
}
