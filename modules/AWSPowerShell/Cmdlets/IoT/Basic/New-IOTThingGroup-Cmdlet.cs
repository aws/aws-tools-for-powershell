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
    /// Create a thing group.
    /// 
    ///  <note><para>
    /// This is a control plane operation. See <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-authorization.html">Authorization</a>
    /// for information about authorizing control plane actions.
    /// </para><para>
    /// If the <c>ThingGroup</c> that you create has the exact same attributes as an existing
    /// <c>ThingGroup</c>, you will get a 200 success response. 
    /// </para></note><para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateThingGroup</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTThingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateThingGroupResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateThingGroup API operation.", Operation = new[] {"CreateThingGroup"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateThingGroupResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateThingGroupResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateThingGroupResponse object containing multiple properties."
    )]
    public partial class NewIOTThingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
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
        
        #region Parameter ParentGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parent thing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentGroupName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata which can be used to manage the thing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
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
        /// <para>The thing group name to create.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateThingGroupResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateThingGroupResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTThingGroup (CreateThingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateThingGroupResponse, NewIOTThingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ParentGroupName = this.ParentGroupName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.IoT.Model.CreateThingGroupRequest();
            
            if (cmdletContext.ParentGroupName != null)
            {
                request.ParentGroupName = cmdletContext.ParentGroupName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoT.Model.CreateThingGroupResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateThingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateThingGroup");
            try
            {
                return client.CreateThingGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ParentGroupName { get; set; }
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.String ThingGroupName { get; set; }
            public Amazon.IoT.Model.AttributePayload ThingGroupProperties_AttributePayload { get; set; }
            public System.String ThingGroupProperties_ThingGroupDescription { get; set; }
            public System.Func<Amazon.IoT.Model.CreateThingGroupResponse, NewIOTThingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
