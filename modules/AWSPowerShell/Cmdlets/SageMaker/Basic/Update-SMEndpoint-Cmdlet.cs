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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Deploys the new <code>EndpointConfig</code> specified in the request, switches to
    /// using newly created endpoint, and then deletes resources provisioned for the endpoint
    /// using the previous <code>EndpointConfig</code> (there is no availability loss). 
    /// 
    ///  
    /// <para>
    /// When Amazon SageMaker receives the request, it sets the endpoint status to <code>Updating</code>.
    /// After updating the endpoint, it sets the status to <code>InService</code>. To check
    /// the status of an endpoint, use the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/API_DescribeEndpoint.html">DescribeEndpoint</a>
    /// API. 
    /// </para><note><para>
    /// You must not delete an <code>EndpointConfig</code> in use by an endpoint that is live
    /// or while the <code>UpdateEndpoint</code> or <code>CreateEndpoint</code> operations
    /// are being performed on the endpoint. To update an endpoint, you must create a new
    /// <code>EndpointConfig</code>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SMEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateEndpoint API operation.", Operation = new[] {"UpdateEndpoint"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateEndpointResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateEndpointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMEndpointCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter EndpointConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the new endpoint configuration.</para>
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
        public System.String EndpointConfigName { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint whose configuration you want to update.</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter ExcludeRetainedVariantProperty
        /// <summary>
        /// <para>
        /// <para>When you are updating endpoint resources with <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/API_UpdateEndpoint.html#SageMaker-UpdateEndpoint-request-RetainAllVariantProperties">RetainAllVariantProperties</a>,
        /// whose value is set to <code>true</code>, <code>ExcludeRetainedVariantProperties</code>
        /// specifies the list of type <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/API_VariantProperty.html">VariantProperty</a>
        /// to override with the values provided by <code>EndpointConfig</code>. If you don't
        /// specify a value for <code>ExcludeAllVariantProperties</code>, no variant properties
        /// are overridden. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeRetainedVariantProperties")]
        public Amazon.SageMaker.Model.VariantProperty[] ExcludeRetainedVariantProperty { get; set; }
        #endregion
        
        #region Parameter RetainAllVariantProperty
        /// <summary>
        /// <para>
        /// <para>When updating endpoint resources, enables or disables the retention of variant properties,
        /// such as the instance count or the variant weight. To retain the variant properties
        /// of an endpoint when updating it, set <code>RetainAllVariantProperties</code> to <code>true</code>.
        /// To use the variant properties specified in a new <code>EndpointConfig</code> call
        /// when updating an endpoint, set <code>RetainAllVariantProperties</code> to <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetainAllVariantProperties")]
        public System.Boolean? RetainAllVariantProperty { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateEndpointResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EndpointConfigName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EndpointConfigName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EndpointConfigName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMEndpoint (UpdateEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateEndpointResponse, UpdateSMEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EndpointConfigName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndpointConfigName = this.EndpointConfigName;
            #if MODULAR
            if (this.EndpointConfigName == null && ParameterWasBound(nameof(this.EndpointConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExcludeRetainedVariantProperty != null)
            {
                context.ExcludeRetainedVariantProperty = new List<Amazon.SageMaker.Model.VariantProperty>(this.ExcludeRetainedVariantProperty);
            }
            context.RetainAllVariantProperty = this.RetainAllVariantProperty;
            
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
            var request = new Amazon.SageMaker.Model.UpdateEndpointRequest();
            
            if (cmdletContext.EndpointConfigName != null)
            {
                request.EndpointConfigName = cmdletContext.EndpointConfigName;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.ExcludeRetainedVariantProperty != null)
            {
                request.ExcludeRetainedVariantProperties = cmdletContext.ExcludeRetainedVariantProperty;
            }
            if (cmdletContext.RetainAllVariantProperty != null)
            {
                request.RetainAllVariantProperties = cmdletContext.RetainAllVariantProperty.Value;
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
        
        private Amazon.SageMaker.Model.UpdateEndpointResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateEndpoint(request);
                #elif CORECLR
                return client.UpdateEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String EndpointConfigName { get; set; }
            public System.String EndpointName { get; set; }
            public List<Amazon.SageMaker.Model.VariantProperty> ExcludeRetainedVariantProperty { get; set; }
            public System.Boolean? RetainAllVariantProperty { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateEndpointResponse, UpdateSMEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointArn;
        }
        
    }
}
