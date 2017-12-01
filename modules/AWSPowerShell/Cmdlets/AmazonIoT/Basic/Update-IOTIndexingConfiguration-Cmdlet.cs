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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates the search configuration.
    /// </summary>
    [Cmdlet("Update", "IOTIndexingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","Amazon.IoT.ThingIndexingMode")]
    [AWSCmdlet("Calls the AWS IoT UpdateIndexingConfiguration API operation.", Operation = new[] {"UpdateIndexingConfiguration"})]
    [AWSCmdletOutput("None or Amazon.IoT.ThingIndexingMode",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ThingIndexingConfiguration_ThingIndexingMode parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.UpdateIndexingConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTIndexingConfigurationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter ThingIndexingConfiguration_ThingIndexingMode
        /// <summary>
        /// <para>
        /// <para>Thing indexing mode. Valid values are: </para><ul><li><para>REGISTRY – Your thing index will contain only registry data.</para></li><li><para>REGISTRY_AND_SHADOW - Your thing index will contain registry and shadow data.</para></li><li><para>OFF - Thing indexing is disabled.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.IoT.ThingIndexingMode")]
        public Amazon.IoT.ThingIndexingMode ThingIndexingConfiguration_ThingIndexingMode { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ThingIndexingConfiguration_ThingIndexingMode parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ThingIndexingConfiguration_ThingIndexingMode", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTIndexingConfiguration (UpdateIndexingConfiguration)"))
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
            
            context.ThingIndexingConfiguration_ThingIndexingMode = this.ThingIndexingConfiguration_ThingIndexingMode;
            
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
            var request = new Amazon.IoT.Model.UpdateIndexingConfigurationRequest();
            
            
             // populate ThingIndexingConfiguration
            bool requestThingIndexingConfigurationIsNull = true;
            request.ThingIndexingConfiguration = new Amazon.IoT.Model.ThingIndexingConfiguration();
            Amazon.IoT.ThingIndexingMode requestThingIndexingConfiguration_thingIndexingConfiguration_ThingIndexingMode = null;
            if (cmdletContext.ThingIndexingConfiguration_ThingIndexingMode != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_ThingIndexingMode = cmdletContext.ThingIndexingConfiguration_ThingIndexingMode;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_ThingIndexingMode != null)
            {
                request.ThingIndexingConfiguration.ThingIndexingMode = requestThingIndexingConfiguration_thingIndexingConfiguration_ThingIndexingMode;
                requestThingIndexingConfigurationIsNull = false;
            }
             // determine if request.ThingIndexingConfiguration should be set to null
            if (requestThingIndexingConfigurationIsNull)
            {
                request.ThingIndexingConfiguration = null;
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
                    pipelineOutput = this.ThingIndexingConfiguration_ThingIndexingMode;
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
        
        private Amazon.IoT.Model.UpdateIndexingConfigurationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateIndexingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateIndexingConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateIndexingConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateIndexingConfigurationAsync(request);
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
            public Amazon.IoT.ThingIndexingMode ThingIndexingConfiguration_ThingIndexingMode { get; set; }
        }
        
    }
}
