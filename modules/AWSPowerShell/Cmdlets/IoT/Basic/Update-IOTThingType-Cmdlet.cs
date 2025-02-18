/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a thing type.
    /// </summary>
    [Cmdlet("Update", "IOTThingType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdateThingType API operation.", Operation = new[] {"UpdateThingType"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateThingTypeResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.UpdateThingTypeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.UpdateThingTypeResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTThingTypeCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Mqtt5Configuration_PropagatingAttribute
        /// <summary>
        /// <para>
        /// <para>An object that represents the propagating thing attributes and the connection attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingTypeProperties_Mqtt5Configuration_PropagatingAttributes")]
        public Amazon.IoT.Model.PropagatingAttribute[] Mqtt5Configuration_PropagatingAttribute { get; set; }
        #endregion
        
        #region Parameter ThingTypeProperties_SearchableAttribute
        /// <summary>
        /// <para>
        /// <para>A list of searchable thing attribute names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingTypeProperties_SearchableAttributes")]
        public System.String[] ThingTypeProperties_SearchableAttribute { get; set; }
        #endregion
        
        #region Parameter ThingTypeProperties_ThingTypeDescription
        /// <summary>
        /// <para>
        /// <para>The description of the thing type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThingTypeProperties_ThingTypeDescription { get; set; }
        #endregion
        
        #region Parameter ThingTypeName
        /// <summary>
        /// <para>
        /// <para>The name of a thing type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ThingTypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateThingTypeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingTypeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTThingType (UpdateThingType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateThingTypeResponse, UpdateIOTThingTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ThingTypeName = this.ThingTypeName;
            #if MODULAR
            if (this.ThingTypeName == null && ParameterWasBound(nameof(this.ThingTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ThingTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Mqtt5Configuration_PropagatingAttribute != null)
            {
                context.Mqtt5Configuration_PropagatingAttribute = new List<Amazon.IoT.Model.PropagatingAttribute>(this.Mqtt5Configuration_PropagatingAttribute);
            }
            if (this.ThingTypeProperties_SearchableAttribute != null)
            {
                context.ThingTypeProperties_SearchableAttribute = new List<System.String>(this.ThingTypeProperties_SearchableAttribute);
            }
            context.ThingTypeProperties_ThingTypeDescription = this.ThingTypeProperties_ThingTypeDescription;
            
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
            var request = new Amazon.IoT.Model.UpdateThingTypeRequest();
            
            if (cmdletContext.ThingTypeName != null)
            {
                request.ThingTypeName = cmdletContext.ThingTypeName;
            }
            
             // populate ThingTypeProperties
            var requestThingTypePropertiesIsNull = true;
            request.ThingTypeProperties = new Amazon.IoT.Model.ThingTypeProperties();
            List<System.String> requestThingTypeProperties_thingTypeProperties_SearchableAttribute = null;
            if (cmdletContext.ThingTypeProperties_SearchableAttribute != null)
            {
                requestThingTypeProperties_thingTypeProperties_SearchableAttribute = cmdletContext.ThingTypeProperties_SearchableAttribute;
            }
            if (requestThingTypeProperties_thingTypeProperties_SearchableAttribute != null)
            {
                request.ThingTypeProperties.SearchableAttributes = requestThingTypeProperties_thingTypeProperties_SearchableAttribute;
                requestThingTypePropertiesIsNull = false;
            }
            System.String requestThingTypeProperties_thingTypeProperties_ThingTypeDescription = null;
            if (cmdletContext.ThingTypeProperties_ThingTypeDescription != null)
            {
                requestThingTypeProperties_thingTypeProperties_ThingTypeDescription = cmdletContext.ThingTypeProperties_ThingTypeDescription;
            }
            if (requestThingTypeProperties_thingTypeProperties_ThingTypeDescription != null)
            {
                request.ThingTypeProperties.ThingTypeDescription = requestThingTypeProperties_thingTypeProperties_ThingTypeDescription;
                requestThingTypePropertiesIsNull = false;
            }
            Amazon.IoT.Model.Mqtt5Configuration requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration = null;
            
             // populate Mqtt5Configuration
            var requestThingTypeProperties_thingTypeProperties_Mqtt5ConfigurationIsNull = true;
            requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration = new Amazon.IoT.Model.Mqtt5Configuration();
            List<Amazon.IoT.Model.PropagatingAttribute> requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration_mqtt5Configuration_PropagatingAttribute = null;
            if (cmdletContext.Mqtt5Configuration_PropagatingAttribute != null)
            {
                requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration_mqtt5Configuration_PropagatingAttribute = cmdletContext.Mqtt5Configuration_PropagatingAttribute;
            }
            if (requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration_mqtt5Configuration_PropagatingAttribute != null)
            {
                requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration.PropagatingAttributes = requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration_mqtt5Configuration_PropagatingAttribute;
                requestThingTypeProperties_thingTypeProperties_Mqtt5ConfigurationIsNull = false;
            }
             // determine if requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration should be set to null
            if (requestThingTypeProperties_thingTypeProperties_Mqtt5ConfigurationIsNull)
            {
                requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration = null;
            }
            if (requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration != null)
            {
                request.ThingTypeProperties.Mqtt5Configuration = requestThingTypeProperties_thingTypeProperties_Mqtt5Configuration;
                requestThingTypePropertiesIsNull = false;
            }
             // determine if request.ThingTypeProperties should be set to null
            if (requestThingTypePropertiesIsNull)
            {
                request.ThingTypeProperties = null;
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
        
        private Amazon.IoT.Model.UpdateThingTypeResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateThingTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateThingType");
            try
            {
                return client.UpdateThingTypeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ThingTypeName { get; set; }
            public List<Amazon.IoT.Model.PropagatingAttribute> Mqtt5Configuration_PropagatingAttribute { get; set; }
            public List<System.String> ThingTypeProperties_SearchableAttribute { get; set; }
            public System.String ThingTypeProperties_ThingTypeDescription { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateThingTypeResponse, UpdateIOTThingTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
