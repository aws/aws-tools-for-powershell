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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Registers a set of tag keys to include in scheduled event notifications for your resources.
    /// 
    /// 
    ///  
    /// <para>
    /// To remove tags, use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DeregisterInstanceEventNotificationAttributes.html">DeregisterInstanceEventNotificationAttributes</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2InstanceEventNotificationAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.InstanceTagNotificationAttribute")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) RegisterInstanceEventNotificationAttributes API operation.", Operation = new[] {"RegisterInstanceEventNotificationAttributes"}, SelectReturnType = typeof(Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceTagNotificationAttribute or Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesResponse",
        "This cmdlet returns an Amazon.EC2.Model.InstanceTagNotificationAttribute object.",
        "The service call response (type Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterEC2InstanceEventNotificationAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceTagAttribute_IncludeAllTagsOfInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to register all tag keys in the current Region. Specify <c>true</c>
        /// to register all tag keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Boolean? InstanceTagAttribute_IncludeAllTagsOfInstance { get; set; }
        #endregion
        
        #region Parameter InstanceTagAttribute_InstanceTagKey
        /// <summary>
        /// <para>
        /// <para>The tag keys to register.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTagAttribute_InstanceTagKeys")]
        public System.String[] InstanceTagAttribute_InstanceTagKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceTagAttribute'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceTagAttribute";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceTagAttribute_IncludeAllTagsOfInstance parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceTagAttribute_IncludeAllTagsOfInstance' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceTagAttribute_IncludeAllTagsOfInstance' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceTagAttribute_IncludeAllTagsOfInstance), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2InstanceEventNotificationAttribute (RegisterInstanceEventNotificationAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesResponse, RegisterEC2InstanceEventNotificationAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceTagAttribute_IncludeAllTagsOfInstance;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceTagAttribute_IncludeAllTagsOfInstance = this.InstanceTagAttribute_IncludeAllTagsOfInstance;
            if (this.InstanceTagAttribute_InstanceTagKey != null)
            {
                context.InstanceTagAttribute_InstanceTagKey = new List<System.String>(this.InstanceTagAttribute_InstanceTagKey);
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
            var request = new Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesRequest();
            
            
             // populate InstanceTagAttribute
            var requestInstanceTagAttributeIsNull = true;
            request.InstanceTagAttribute = new Amazon.EC2.Model.RegisterInstanceTagAttributeRequest();
            System.Boolean? requestInstanceTagAttribute_instanceTagAttribute_IncludeAllTagsOfInstance = null;
            if (cmdletContext.InstanceTagAttribute_IncludeAllTagsOfInstance != null)
            {
                requestInstanceTagAttribute_instanceTagAttribute_IncludeAllTagsOfInstance = cmdletContext.InstanceTagAttribute_IncludeAllTagsOfInstance.Value;
            }
            if (requestInstanceTagAttribute_instanceTagAttribute_IncludeAllTagsOfInstance != null)
            {
                request.InstanceTagAttribute.IncludeAllTagsOfInstance = requestInstanceTagAttribute_instanceTagAttribute_IncludeAllTagsOfInstance.Value;
                requestInstanceTagAttributeIsNull = false;
            }
            List<System.String> requestInstanceTagAttribute_instanceTagAttribute_InstanceTagKey = null;
            if (cmdletContext.InstanceTagAttribute_InstanceTagKey != null)
            {
                requestInstanceTagAttribute_instanceTagAttribute_InstanceTagKey = cmdletContext.InstanceTagAttribute_InstanceTagKey;
            }
            if (requestInstanceTagAttribute_instanceTagAttribute_InstanceTagKey != null)
            {
                request.InstanceTagAttribute.InstanceTagKeys = requestInstanceTagAttribute_instanceTagAttribute_InstanceTagKey;
                requestInstanceTagAttributeIsNull = false;
            }
             // determine if request.InstanceTagAttribute should be set to null
            if (requestInstanceTagAttributeIsNull)
            {
                request.InstanceTagAttribute = null;
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
        
        private Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "RegisterInstanceEventNotificationAttributes");
            try
            {
                #if DESKTOP
                return client.RegisterInstanceEventNotificationAttributes(request);
                #elif CORECLR
                return client.RegisterInstanceEventNotificationAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? InstanceTagAttribute_IncludeAllTagsOfInstance { get; set; }
            public List<System.String> InstanceTagAttribute_InstanceTagKey { get; set; }
            public System.Func<Amazon.EC2.Model.RegisterInstanceEventNotificationAttributesResponse, RegisterEC2InstanceEventNotificationAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceTagAttribute;
        }
        
    }
}
