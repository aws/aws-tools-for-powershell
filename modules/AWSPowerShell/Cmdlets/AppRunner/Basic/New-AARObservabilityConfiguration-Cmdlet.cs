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
    /// Create an App Runner observability configuration resource. App Runner requires this
    /// resource when you create or update App Runner services and you want to enable non-default
    /// observability features. You can share an observability configuration across multiple
    /// services.
    /// 
    ///  
    /// <para>
    /// Create multiple revisions of a configuration by calling this action multiple times
    /// using the same <code>ObservabilityConfigurationName</code>. The call returns incremental
    /// <code>ObservabilityConfigurationRevision</code> values. When you create a service
    /// and configure an observability configuration resource, the service uses the latest
    /// active revision of the observability configuration by default. You can optionally
    /// configure the service to use a specific revision.
    /// </para><para>
    /// The observability configuration resource is designed to configure multiple features
    /// (currently one feature, tracing). This action takes optional parameters that describe
    /// the configuration of these features (currently one parameter, <code>TraceConfiguration</code>).
    /// If you don't specify a feature parameter, App Runner doesn't enable the feature.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AARObservabilityConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppRunner.Model.ObservabilityConfiguration")]
    [AWSCmdlet("Calls the AWS App Runner CreateObservabilityConfiguration API operation.", Operation = new[] {"CreateObservabilityConfiguration"}, SelectReturnType = typeof(Amazon.AppRunner.Model.CreateObservabilityConfigurationResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.ObservabilityConfiguration or Amazon.AppRunner.Model.CreateObservabilityConfigurationResponse",
        "This cmdlet returns an Amazon.AppRunner.Model.ObservabilityConfiguration object.",
        "The service call response (type Amazon.AppRunner.Model.CreateObservabilityConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAARObservabilityConfigurationCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        #region Parameter ObservabilityConfigurationName
        /// <summary>
        /// <para>
        /// <para>A name for the observability configuration. When you use it for the first time in
        /// an Amazon Web Services Region, App Runner creates revision number <code>1</code> of
        /// this name. When you use the same name in subsequent calls, App Runner creates incremental
        /// revisions of the configuration.</para><note><para>The name <code>DefaultConfiguration</code> is reserved. You can't use it to create
        /// a new observability configuration, and you can't create a revision of it.</para><para>When you want to use your own observability configuration for your App Runner service,
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
        public System.String ObservabilityConfigurationName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of metadata items that you can associate with your observability configuration
        /// resource. A tag is a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppRunner.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TraceConfiguration_Vendor
        /// <summary>
        /// <para>
        /// <para>The implementation provider chosen for tracing App Runner services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppRunner.TracingVendor")]
        public Amazon.AppRunner.TracingVendor TraceConfiguration_Vendor { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ObservabilityConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.CreateObservabilityConfigurationResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.CreateObservabilityConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ObservabilityConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ObservabilityConfigurationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ObservabilityConfigurationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ObservabilityConfigurationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ObservabilityConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AARObservabilityConfiguration (CreateObservabilityConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.CreateObservabilityConfigurationResponse, NewAARObservabilityConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ObservabilityConfigurationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ObservabilityConfigurationName = this.ObservabilityConfigurationName;
            #if MODULAR
            if (this.ObservabilityConfigurationName == null && ParameterWasBound(nameof(this.ObservabilityConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ObservabilityConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppRunner.Model.Tag>(this.Tag);
            }
            context.TraceConfiguration_Vendor = this.TraceConfiguration_Vendor;
            
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
            var request = new Amazon.AppRunner.Model.CreateObservabilityConfigurationRequest();
            
            if (cmdletContext.ObservabilityConfigurationName != null)
            {
                request.ObservabilityConfigurationName = cmdletContext.ObservabilityConfigurationName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TraceConfiguration
            var requestTraceConfigurationIsNull = true;
            request.TraceConfiguration = new Amazon.AppRunner.Model.TraceConfiguration();
            Amazon.AppRunner.TracingVendor requestTraceConfiguration_traceConfiguration_Vendor = null;
            if (cmdletContext.TraceConfiguration_Vendor != null)
            {
                requestTraceConfiguration_traceConfiguration_Vendor = cmdletContext.TraceConfiguration_Vendor;
            }
            if (requestTraceConfiguration_traceConfiguration_Vendor != null)
            {
                request.TraceConfiguration.Vendor = requestTraceConfiguration_traceConfiguration_Vendor;
                requestTraceConfigurationIsNull = false;
            }
             // determine if request.TraceConfiguration should be set to null
            if (requestTraceConfigurationIsNull)
            {
                request.TraceConfiguration = null;
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
        
        private Amazon.AppRunner.Model.CreateObservabilityConfigurationResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.CreateObservabilityConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "CreateObservabilityConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateObservabilityConfiguration(request);
                #elif CORECLR
                return client.CreateObservabilityConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ObservabilityConfigurationName { get; set; }
            public List<Amazon.AppRunner.Model.Tag> Tag { get; set; }
            public Amazon.AppRunner.TracingVendor TraceConfiguration_Vendor { get; set; }
            public System.Func<Amazon.AppRunner.Model.CreateObservabilityConfigurationResponse, NewAARObservabilityConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ObservabilityConfiguration;
        }
        
    }
}
