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
    /// Update a thing group.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateThingGroup</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTThingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the AWS IoT UpdateThingGroup API operation.", Operation = new[] {"UpdateThingGroup"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateThingGroupResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.IoT.Model.UpdateThingGroupResponse",
        "This cmdlet returns a collection of System.Int64 objects.",
        "The service call response (type Amazon.IoT.Model.UpdateThingGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTThingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ThingGroupProperties_AttributePayload
        /// <summary>
        /// <para>
        /// <para>The thing group attributes in JSON format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoT.Model.AttributePayload ThingGroupProperties_AttributePayload { get; set; }
        #endregion
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the thing group. If this does not match the version of the
        /// thing group being updated, the update will fail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter ThingGroupProperties_ThingGroupDescription
        /// <summary>
        /// <para>
        /// <para>The thing group description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThingGroupProperties_ThingGroupDescription { get; set; }
        #endregion
        
        #region Parameter ThingGroupName
        /// <summary>
        /// <para>
        /// <para>The thing group to update.</para>
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
        public System.String ThingGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Version'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateThingGroupResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateThingGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Version";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTThingGroup (UpdateThingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateThingGroupResponse, UpdateIOTThingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExpectedVersion = this.ExpectedVersion;
            context.ThingGroupName = this.ThingGroupName;
            #if MODULAR
            if (this.ThingGroupName == null && ParameterWasBound(nameof(this.ThingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ThingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThingGroupProperties_AttributePayload = this.ThingGroupProperties_AttributePayload;
            context.ThingGroupProperties_ThingGroupDescription = this.ThingGroupProperties_ThingGroupDescription;
            
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
            var request = new Amazon.IoT.Model.UpdateThingGroupRequest();
            
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
            }
            if (cmdletContext.ThingGroupName != null)
            {
                request.ThingGroupName = cmdletContext.ThingGroupName;
            }
            
             // populate ThingGroupProperties
            var requestThingGroupPropertiesIsNull = true;
            request.ThingGroupProperties = new Amazon.IoT.Model.ThingGroupProperties();
            Amazon.IoT.Model.AttributePayload requestThingGroupProperties_thingGroupProperties_AttributePayload = null;
            if (cmdletContext.ThingGroupProperties_AttributePayload != null)
            {
                requestThingGroupProperties_thingGroupProperties_AttributePayload = cmdletContext.ThingGroupProperties_AttributePayload;
            }
            if (requestThingGroupProperties_thingGroupProperties_AttributePayload != null)
            {
                request.ThingGroupProperties.AttributePayload = requestThingGroupProperties_thingGroupProperties_AttributePayload;
                requestThingGroupPropertiesIsNull = false;
            }
            System.String requestThingGroupProperties_thingGroupProperties_ThingGroupDescription = null;
            if (cmdletContext.ThingGroupProperties_ThingGroupDescription != null)
            {
                requestThingGroupProperties_thingGroupProperties_ThingGroupDescription = cmdletContext.ThingGroupProperties_ThingGroupDescription;
            }
            if (requestThingGroupProperties_thingGroupProperties_ThingGroupDescription != null)
            {
                request.ThingGroupProperties.ThingGroupDescription = requestThingGroupProperties_thingGroupProperties_ThingGroupDescription;
                requestThingGroupPropertiesIsNull = false;
            }
             // determine if request.ThingGroupProperties should be set to null
            if (requestThingGroupPropertiesIsNull)
            {
                request.ThingGroupProperties = null;
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
        
        private Amazon.IoT.Model.UpdateThingGroupResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateThingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateThingGroup");
            try
            {
                return client.UpdateThingGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? ExpectedVersion { get; set; }
            public System.String ThingGroupName { get; set; }
            public Amazon.IoT.Model.AttributePayload ThingGroupProperties_AttributePayload { get; set; }
            public System.String ThingGroupProperties_ThingGroupDescription { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateThingGroupResponse, UpdateIOTThingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Version;
        }
        
    }
}
