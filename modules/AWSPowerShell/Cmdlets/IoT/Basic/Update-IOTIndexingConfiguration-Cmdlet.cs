/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdateIndexingConfiguration API operation.", Operation = new[] {"UpdateIndexingConfiguration"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateIndexingConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.UpdateIndexingConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.UpdateIndexingConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTIndexingConfigurationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter ThingIndexingConfiguration_ThingConnectivityIndexingMode
        /// <summary>
        /// <para>
        /// <para>Thing connectivity indexing mode. Valid values are: </para><ul><li><para>STATUS – Your thing index contains connectivity status. To enable thing connectivity
        /// indexing, thingIndexMode must not be set to OFF.</para></li><li><para>OFF - Thing connectivity status indexing is disabled.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.ThingConnectivityIndexingMode")]
        public Amazon.IoT.ThingConnectivityIndexingMode ThingIndexingConfiguration_ThingConnectivityIndexingMode { get; set; }
        #endregion
        
        #region Parameter ThingGroupIndexingConfiguration_ThingGroupIndexingMode
        /// <summary>
        /// <para>
        /// <para>Thing group indexing mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.ThingGroupIndexingMode")]
        public Amazon.IoT.ThingGroupIndexingMode ThingGroupIndexingConfiguration_ThingGroupIndexingMode { get; set; }
        #endregion
        
        #region Parameter ThingIndexingConfiguration_ThingIndexingMode
        /// <summary>
        /// <para>
        /// <para>Thing indexing mode. Valid values are:</para><ul><li><para>REGISTRY – Your thing index contains registry data only.</para></li><li><para>REGISTRY_AND_SHADOW - Your thing index contains registry and shadow data.</para></li><li><para>OFF - Thing indexing is disabled.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.IoT.ThingIndexingMode")]
        public Amazon.IoT.ThingIndexingMode ThingIndexingConfiguration_ThingIndexingMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateIndexingConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ThingIndexingConfiguration_ThingIndexingMode parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ThingIndexingConfiguration_ThingIndexingMode' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ThingIndexingConfiguration_ThingIndexingMode' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingIndexingConfiguration_ThingIndexingMode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTIndexingConfiguration (UpdateIndexingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateIndexingConfigurationResponse, UpdateIOTIndexingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ThingIndexingConfiguration_ThingIndexingMode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ThingGroupIndexingConfiguration_ThingGroupIndexingMode = this.ThingGroupIndexingConfiguration_ThingGroupIndexingMode;
            context.ThingIndexingConfiguration_ThingConnectivityIndexingMode = this.ThingIndexingConfiguration_ThingConnectivityIndexingMode;
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
            
            
             // populate ThingGroupIndexingConfiguration
            var requestThingGroupIndexingConfigurationIsNull = true;
            request.ThingGroupIndexingConfiguration = new Amazon.IoT.Model.ThingGroupIndexingConfiguration();
            Amazon.IoT.ThingGroupIndexingMode requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ThingGroupIndexingMode = null;
            if (cmdletContext.ThingGroupIndexingConfiguration_ThingGroupIndexingMode != null)
            {
                requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ThingGroupIndexingMode = cmdletContext.ThingGroupIndexingConfiguration_ThingGroupIndexingMode;
            }
            if (requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ThingGroupIndexingMode != null)
            {
                request.ThingGroupIndexingConfiguration.ThingGroupIndexingMode = requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ThingGroupIndexingMode;
                requestThingGroupIndexingConfigurationIsNull = false;
            }
             // determine if request.ThingGroupIndexingConfiguration should be set to null
            if (requestThingGroupIndexingConfigurationIsNull)
            {
                request.ThingGroupIndexingConfiguration = null;
            }
            
             // populate ThingIndexingConfiguration
            var requestThingIndexingConfigurationIsNull = true;
            request.ThingIndexingConfiguration = new Amazon.IoT.Model.ThingIndexingConfiguration();
            Amazon.IoT.ThingConnectivityIndexingMode requestThingIndexingConfiguration_thingIndexingConfiguration_ThingConnectivityIndexingMode = null;
            if (cmdletContext.ThingIndexingConfiguration_ThingConnectivityIndexingMode != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_ThingConnectivityIndexingMode = cmdletContext.ThingIndexingConfiguration_ThingConnectivityIndexingMode;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_ThingConnectivityIndexingMode != null)
            {
                request.ThingIndexingConfiguration.ThingConnectivityIndexingMode = requestThingIndexingConfiguration_thingIndexingConfiguration_ThingConnectivityIndexingMode;
                requestThingIndexingConfigurationIsNull = false;
            }
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.UpdateIndexingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoT.ThingGroupIndexingMode ThingGroupIndexingConfiguration_ThingGroupIndexingMode { get; set; }
            public Amazon.IoT.ThingConnectivityIndexingMode ThingIndexingConfiguration_ThingConnectivityIndexingMode { get; set; }
            public Amazon.IoT.ThingIndexingMode ThingIndexingConfiguration_ThingIndexingMode { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateIndexingConfigurationResponse, UpdateIOTIndexingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
