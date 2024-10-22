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
    /// Creates a billing group.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateBillingGroup</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTBillingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateBillingGroupResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateBillingGroup API operation.", Operation = new[] {"CreateBillingGroup"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateBillingGroupResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateBillingGroupResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateBillingGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTBillingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
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
        /// <para>The name you wish to give to the billing group.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata which can be used to manage the billing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateBillingGroupResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateBillingGroupResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BillingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTBillingGroup (CreateBillingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateBillingGroupResponse, NewIOTBillingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingGroupName = this.BillingGroupName;
            #if MODULAR
            if (this.BillingGroupName == null && ParameterWasBound(nameof(this.BillingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter BillingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BillingGroupProperties_BillingGroupDescription = this.BillingGroupProperties_BillingGroupDescription;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoT.Model.CreateBillingGroupRequest();
            
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoT.Model.CreateBillingGroupResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateBillingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateBillingGroup");
            try
            {
                #if DESKTOP
                return client.CreateBillingGroup(request);
                #elif CORECLR
                return client.CreateBillingGroupAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoT.Model.CreateBillingGroupResponse, NewIOTBillingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
