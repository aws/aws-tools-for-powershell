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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Modifies the properties of the specified Amazon WorkSpaces client.
    /// </summary>
    [Cmdlet("Edit", "WKSClientProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","Amazon.WorkSpaces.ReconnectEnum")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifyClientProperties API operation.", Operation = new[] {"ModifyClientProperties"})]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.ReconnectEnum",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ClientProperties_ReconnectEnabled parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditWKSClientPropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter ClientProperties_ReconnectEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can cache their credentials on the Amazon WorkSpaces client.
        /// When enabled, users can choose to reconnect to their WorkSpaces without re-entering
        /// their credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.ReconnectEnum")]
        public Amazon.WorkSpaces.ReconnectEnum ClientProperties_ReconnectEnabled { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The resource identifiers, in the form of directory IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ClientProperties_ReconnectEnabled parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSClientProperty (ModifyClientProperties)"))
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
            
            context.ClientProperties_ReconnectEnabled = this.ClientProperties_ReconnectEnabled;
            context.ResourceId = this.ResourceId;
            
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
            var request = new Amazon.WorkSpaces.Model.ModifyClientPropertiesRequest();
            
            
             // populate ClientProperties
            bool requestClientPropertiesIsNull = true;
            request.ClientProperties = new Amazon.WorkSpaces.Model.ClientProperties();
            Amazon.WorkSpaces.ReconnectEnum requestClientProperties_clientProperties_ReconnectEnabled = null;
            if (cmdletContext.ClientProperties_ReconnectEnabled != null)
            {
                requestClientProperties_clientProperties_ReconnectEnabled = cmdletContext.ClientProperties_ReconnectEnabled;
            }
            if (requestClientProperties_clientProperties_ReconnectEnabled != null)
            {
                request.ClientProperties.ReconnectEnabled = requestClientProperties_clientProperties_ReconnectEnabled;
                requestClientPropertiesIsNull = false;
            }
             // determine if request.ClientProperties should be set to null
            if (requestClientPropertiesIsNull)
            {
                request.ClientProperties = null;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
                    pipelineOutput = this.ClientProperties_ReconnectEnabled;
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
        
        private Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifyClientPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifyClientProperties");
            try
            {
                #if DESKTOP
                return client.ModifyClientProperties(request);
                #elif CORECLR
                return client.ModifyClientPropertiesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WorkSpaces.ReconnectEnum ClientProperties_ReconnectEnabled { get; set; }
            public System.String ResourceId { get; set; }
        }
        
    }
}
