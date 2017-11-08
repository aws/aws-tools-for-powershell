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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Adds or removes domain controllers to or from the directory. Based on the difference
    /// between current value and new value (provided through this API call), domain controllers
    /// will be added or removed. It may take up to 45 minutes for any new domain controllers
    /// to become fully active once the requested number of domain controllers is updated.
    /// During this time, you cannot make another update request.
    /// </summary>
    [Cmdlet("Set", "DSDomainControllerCount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.Int32")]
    [AWSCmdlet("Calls the AWS Directory Service UpdateNumberOfDomainControllers API operation.", Operation = new[] {"UpdateNumberOfDomainControllers"})]
    [AWSCmdletOutput("None or System.Int32",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DesiredNumber parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.DirectoryService.Model.UpdateNumberOfDomainControllersResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetDSDomainControllerCountCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DesiredNumber
        /// <summary>
        /// <para>
        /// <para>The number of domain controllers desired in the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.Int32 DesiredNumber { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>Identifier of the directory to which the domain controllers will be added or removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the DesiredNumber parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-DSDomainControllerCount (UpdateNumberOfDomainControllers)"))
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
            
            if (ParameterWasBound("DesiredNumber"))
                context.DesiredNumber = this.DesiredNumber;
            context.DirectoryId = this.DirectoryId;
            
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
            var request = new Amazon.DirectoryService.Model.UpdateNumberOfDomainControllersRequest();
            
            if (cmdletContext.DesiredNumber != null)
            {
                request.DesiredNumber = cmdletContext.DesiredNumber.Value;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
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
                    pipelineOutput = this.DesiredNumber;
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
        
        private Amazon.DirectoryService.Model.UpdateNumberOfDomainControllersResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.UpdateNumberOfDomainControllersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "UpdateNumberOfDomainControllers");
            try
            {
                #if DESKTOP
                return client.UpdateNumberOfDomainControllers(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateNumberOfDomainControllersAsync(request);
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
            public System.Int32? DesiredNumber { get; set; }
            public System.String DirectoryId { get; set; }
        }
        
    }
}
