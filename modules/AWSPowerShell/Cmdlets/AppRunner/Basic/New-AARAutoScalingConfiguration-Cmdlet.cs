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
using Amazon.AppRunner;
using Amazon.AppRunner.Model;

namespace Amazon.PowerShell.Cmdlets.AAR
{
    /// <summary>
    /// Create an App Runner automatic scaling configuration resource. App Runner requires
    /// this resource when you create or update App Runner services and you require non-default
    /// auto scaling settings. You can share an auto scaling configuration across multiple
    /// services.
    /// 
    ///  
    /// <para>
    /// Create multiple revisions of a configuration by calling this action multiple times
    /// using the same <code>AutoScalingConfigurationName</code>. The call returns incremental
    /// <code>AutoScalingConfigurationRevision</code> values. When you create a service and
    /// configure an auto scaling configuration resource, the service uses the latest active
    /// revision of the auto scaling configuration by default. You can optionally configure
    /// the service to use a specific revision.
    /// </para><para>
    /// Configure a higher <code>MinSize</code> to increase the spread of your App Runner
    /// service over more Availability Zones in the Amazon Web Services Region. The tradeoff
    /// is a higher minimal cost.
    /// </para><para>
    /// Configure a lower <code>MaxSize</code> to control your cost. The tradeoff is lower
    /// responsiveness during peak demand.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AARAutoScalingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppRunner.Model.AutoScalingConfiguration")]
    [AWSCmdlet("Calls the AWS App Runner CreateAutoScalingConfiguration API operation.", Operation = new[] {"CreateAutoScalingConfiguration"}, SelectReturnType = typeof(Amazon.AppRunner.Model.CreateAutoScalingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.AutoScalingConfiguration or Amazon.AppRunner.Model.CreateAutoScalingConfigurationResponse",
        "This cmdlet returns an Amazon.AppRunner.Model.AutoScalingConfiguration object.",
        "The service call response (type Amazon.AppRunner.Model.CreateAutoScalingConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAARAutoScalingConfigurationCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingConfigurationName
        /// <summary>
        /// <para>
        /// <para>A name for the auto scaling configuration. When you use it for the first time in an
        /// Amazon Web Services Region, App Runner creates revision number <code>1</code> of this
        /// name. When you use the same name in subsequent calls, App Runner creates incremental
        /// revisions of the configuration.</para><note><para>The name <code>DefaultConfiguration</code> is reserved (it's the configuration that
        /// App Runner uses if you don't provide a custome one). You can't use it to create a
        /// new auto scaling configuration, and you can't create a revision of it.</para><para>When you want to use your own auto scaling configuration for your App Runner service,
        /// <i>create a configuration with a different name</i>, and then provide it when you
        /// create or update your service.</para></note>
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
        public System.String AutoScalingConfigurationName { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent requests that you want an instance to process. If
        /// the number of concurrent requests exceeds this limit, App Runner scales up your service.</para><para>Default: <code>100</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances that your service scales up to. At most <code>MaxSize</code>
        /// instances actively serve traffic for your service.</para><para>Default: <code>25</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSize { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of instances that App Runner provisions for your service. The service
        /// always has at least <code>MinSize</code> provisioned instances. Some of them actively
        /// serve traffic. The rest of them (provisioned and inactive instances) are a cost-effective
        /// compute capacity reserve and are ready to be quickly activated. You pay for memory
        /// usage of all the provisioned instances. You pay for CPU usage of only the active subset.</para><para>App Runner temporarily doubles the number of provisioned instances during deployments,
        /// to maintain the same capacity for both old and new code.</para><para>Default: <code>1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinSize { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of metadata items that you can associate with your auto scaling configuration
        /// resource. A tag is a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppRunner.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutoScalingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.CreateAutoScalingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.CreateAutoScalingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutoScalingConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoScalingConfigurationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoScalingConfigurationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoScalingConfigurationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AARAutoScalingConfiguration (CreateAutoScalingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.CreateAutoScalingConfigurationResponse, NewAARAutoScalingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoScalingConfigurationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingConfigurationName = this.AutoScalingConfigurationName;
            #if MODULAR
            if (this.AutoScalingConfigurationName == null && ParameterWasBound(nameof(this.AutoScalingConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxSize = this.MaxSize;
            context.MinSize = this.MinSize;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppRunner.Model.Tag>(this.Tag);
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
            var request = new Amazon.AppRunner.Model.CreateAutoScalingConfigurationRequest();
            
            if (cmdletContext.AutoScalingConfigurationName != null)
            {
                request.AutoScalingConfigurationName = cmdletContext.AutoScalingConfigurationName;
            }
            if (cmdletContext.MaxConcurrency != null)
            {
                request.MaxConcurrency = cmdletContext.MaxConcurrency.Value;
            }
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
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
        
        private Amazon.AppRunner.Model.CreateAutoScalingConfigurationResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.CreateAutoScalingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "CreateAutoScalingConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateAutoScalingConfiguration(request);
                #elif CORECLR
                return client.CreateAutoScalingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingConfigurationName { get; set; }
            public System.Int32? MaxConcurrency { get; set; }
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public List<Amazon.AppRunner.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.AppRunner.Model.CreateAutoScalingConfigurationResponse, NewAARAutoScalingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutoScalingConfiguration;
        }
        
    }
}
