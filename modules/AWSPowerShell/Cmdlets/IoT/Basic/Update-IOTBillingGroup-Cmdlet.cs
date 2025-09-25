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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates information about the billing group.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateBillingGroup</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTBillingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the AWS IoT UpdateBillingGroup API operation.", Operation = new[] {"UpdateBillingGroup"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateBillingGroupResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.IoT.Model.UpdateBillingGroupResponse",
        "This cmdlet returns a System.Int64 object.",
        "The service call response (type Amazon.IoT.Model.UpdateBillingGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTBillingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BillingGroupProperties_BillingGroupDescription
        /// <summary>
        /// <para>
        /// <para>The description of the billing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BillingGroupProperties_BillingGroupDescription { get; set; }
        #endregion
        
        #region Parameter BillingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the billing group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BillingGroupName { get; set; }
        #endregion
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the billing group. If the version of the billing group does
        /// not match the expected version specified in the request, the <c>UpdateBillingGroup</c>
        /// request is rejected with a <c>VersionConflictException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Version'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateBillingGroupResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateBillingGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Version";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BillingGroupProperties_BillingGroupDescription parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BillingGroupProperties_BillingGroupDescription' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BillingGroupProperties_BillingGroupDescription' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BillingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTBillingGroup (UpdateBillingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateBillingGroupResponse, UpdateIOTBillingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BillingGroupProperties_BillingGroupDescription;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BillingGroupName = this.BillingGroupName;
            #if MODULAR
            if (this.BillingGroupName == null && ParameterWasBound(nameof(this.BillingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter BillingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BillingGroupProperties_BillingGroupDescription = this.BillingGroupProperties_BillingGroupDescription;
            context.ExpectedVersion = this.ExpectedVersion;
            
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
            var request = new Amazon.IoT.Model.UpdateBillingGroupRequest();
            
            if (cmdletContext.BillingGroupName != null)
            {
                request.BillingGroupName = cmdletContext.BillingGroupName;
            }
            
             // populate BillingGroupProperties
            var requestBillingGroupPropertiesIsNull = true;
            request.BillingGroupProperties = new Amazon.IoT.Model.BillingGroupProperties();
            System.String requestBillingGroupProperties_billingGroupProperties_BillingGroupDescription = null;
            if (cmdletContext.BillingGroupProperties_BillingGroupDescription != null)
            {
                requestBillingGroupProperties_billingGroupProperties_BillingGroupDescription = cmdletContext.BillingGroupProperties_BillingGroupDescription;
            }
            if (requestBillingGroupProperties_billingGroupProperties_BillingGroupDescription != null)
            {
                request.BillingGroupProperties.BillingGroupDescription = requestBillingGroupProperties_billingGroupProperties_BillingGroupDescription;
                requestBillingGroupPropertiesIsNull = false;
            }
             // determine if request.BillingGroupProperties should be set to null
            if (requestBillingGroupPropertiesIsNull)
            {
                request.BillingGroupProperties = null;
            }
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
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
        
        private Amazon.IoT.Model.UpdateBillingGroupResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateBillingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateBillingGroup");
            try
            {
                #if DESKTOP
                return client.UpdateBillingGroup(request);
                #elif CORECLR
                return client.UpdateBillingGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String BillingGroupName { get; set; }
            public System.String BillingGroupProperties_BillingGroupDescription { get; set; }
            public System.Int64? ExpectedVersion { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateBillingGroupResponse, UpdateIOTBillingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Version;
        }
        
    }
}
