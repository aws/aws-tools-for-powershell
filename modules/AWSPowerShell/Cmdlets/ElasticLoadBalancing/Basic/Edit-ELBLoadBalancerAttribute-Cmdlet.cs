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
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;

namespace Amazon.PowerShell.Cmdlets.ELB
{
    /// <summary>
    /// Modifies the attributes of the specified load balancer.
    /// 
    ///  
    /// <para>
    /// You can modify the load balancer attributes, such as <code>AccessLogs</code>, <code>ConnectionDraining</code>,
    /// and <code>CrossZoneLoadBalancing</code> by either enabling or disabling them. Or,
    /// you can modify the load balancer attribute <code>ConnectionSettings</code> by specifying
    /// an idle connection timeout value for your load balancer.
    /// </para><para>
    /// For more information, see the following in the <i>Classic Load Balancers Guide</i>:
    /// </para><ul><li><para><a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/enable-disable-crosszone-lb.html">Cross-Zone
    /// Load Balancing</a></para></li><li><para><a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/config-conn-drain.html">Connection
    /// Draining</a></para></li><li><para><a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/access-log-collection.html">Access
    /// Logs</a></para></li><li><para><a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/config-idle-timeout.html">Idle
    /// Connection Timeout</a></para></li></ul>
    /// </summary>
    [Cmdlet("Edit", "ELBLoadBalancerAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse")]
    [AWSCmdlet("Calls the Elastic Load Balancing ModifyLoadBalancerAttributes API operation.", Operation = new[] {"ModifyLoadBalancerAttributes"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse",
        "This cmdlet returns an Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditELBLoadBalancerAttributeCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        #region Parameter LoadBalancerAttributes_AdditionalAttribute
        /// <summary>
        /// <para>
        /// <para>This parameter is reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_AdditionalAttributes")]
        public Amazon.ElasticLoadBalancing.Model.AdditionalAttribute[] LoadBalancerAttributes_AdditionalAttribute { get; set; }
        #endregion
        
        #region Parameter AccessLog_EmitInterval
        /// <summary>
        /// <para>
        /// <para>The interval for publishing the access logs. You can specify an interval of either
        /// 5 minutes or 60 minutes.</para><para>Default: 60 minutes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_AccessLog_EmitInterval")]
        public System.Int32? AccessLog_EmitInterval { get; set; }
        #endregion
        
        #region Parameter AccessLog_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether access logs are enabled for the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_AccessLog_Enabled")]
        public System.Boolean? AccessLog_Enabled { get; set; }
        #endregion
        
        #region Parameter ConnectionDraining_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether connection draining is enabled for the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_ConnectionDraining_Enabled")]
        public System.Boolean? ConnectionDraining_Enabled { get; set; }
        #endregion
        
        #region Parameter CrossZoneLoadBalancing_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether cross-zone load balancing is enabled for the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_CrossZoneLoadBalancing_Enabled")]
        public System.Boolean? CrossZoneLoadBalancing_Enabled { get; set; }
        #endregion
        
        #region Parameter ConnectionSettings_IdleTimeout
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, that the connection is allowed to be idle (no data has been
        /// sent over the connection) before it is closed by the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_ConnectionSettings_IdleTimeout")]
        public System.Int32? ConnectionSettings_IdleTimeout { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para>
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
        public System.String LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter AccessLog_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where the access logs are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_AccessLog_S3BucketName")]
        public System.String AccessLog_S3BucketName { get; set; }
        #endregion
        
        #region Parameter AccessLog_S3BucketPrefix
        /// <summary>
        /// <para>
        /// <para>The logical hierarchy you created for your Amazon S3 bucket, for example <code>my-bucket-prefix/prod</code>.
        /// If the prefix is not provided, the log is placed at the root level of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_AccessLog_S3BucketPrefix")]
        public System.String AccessLog_S3BucketPrefix { get; set; }
        #endregion
        
        #region Parameter ConnectionDraining_Timeout
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, to keep the existing connections open before deregistering
        /// the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerAttributes_ConnectionDraining_Timeout")]
        public System.Int32? ConnectionDraining_Timeout { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LoadBalancerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LoadBalancerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LoadBalancerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ELBLoadBalancerAttribute (ModifyLoadBalancerAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse, EditELBLoadBalancerAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LoadBalancerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessLog_EmitInterval = this.AccessLog_EmitInterval;
            context.AccessLog_Enabled = this.AccessLog_Enabled;
            context.AccessLog_S3BucketName = this.AccessLog_S3BucketName;
            context.AccessLog_S3BucketPrefix = this.AccessLog_S3BucketPrefix;
            if (this.LoadBalancerAttributes_AdditionalAttribute != null)
            {
                context.LoadBalancerAttributes_AdditionalAttribute = new List<Amazon.ElasticLoadBalancing.Model.AdditionalAttribute>(this.LoadBalancerAttributes_AdditionalAttribute);
            }
            context.ConnectionDraining_Enabled = this.ConnectionDraining_Enabled;
            context.ConnectionDraining_Timeout = this.ConnectionDraining_Timeout;
            context.ConnectionSettings_IdleTimeout = this.ConnectionSettings_IdleTimeout;
            context.CrossZoneLoadBalancing_Enabled = this.CrossZoneLoadBalancing_Enabled;
            context.LoadBalancerName = this.LoadBalancerName;
            #if MODULAR
            if (this.LoadBalancerName == null && ParameterWasBound(nameof(this.LoadBalancerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesRequest();
            
            
             // populate LoadBalancerAttributes
            var requestLoadBalancerAttributesIsNull = true;
            request.LoadBalancerAttributes = new Amazon.ElasticLoadBalancing.Model.LoadBalancerAttributes();
            List<Amazon.ElasticLoadBalancing.Model.AdditionalAttribute> requestLoadBalancerAttributes_loadBalancerAttributes_AdditionalAttribute = null;
            if (cmdletContext.LoadBalancerAttributes_AdditionalAttribute != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AdditionalAttribute = cmdletContext.LoadBalancerAttributes_AdditionalAttribute;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_AdditionalAttribute != null)
            {
                request.LoadBalancerAttributes.AdditionalAttributes = requestLoadBalancerAttributes_loadBalancerAttributes_AdditionalAttribute;
                requestLoadBalancerAttributesIsNull = false;
            }
            Amazon.ElasticLoadBalancing.Model.ConnectionSettings requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings = null;
            
             // populate ConnectionSettings
            var requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettingsIsNull = true;
            requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings = new Amazon.ElasticLoadBalancing.Model.ConnectionSettings();
            System.Int32? requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings_connectionSettings_IdleTimeout = null;
            if (cmdletContext.ConnectionSettings_IdleTimeout != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings_connectionSettings_IdleTimeout = cmdletContext.ConnectionSettings_IdleTimeout.Value;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings_connectionSettings_IdleTimeout != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings.IdleTimeout = requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings_connectionSettings_IdleTimeout.Value;
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettingsIsNull = false;
            }
             // determine if requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings should be set to null
            if (requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettingsIsNull)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings = null;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings != null)
            {
                request.LoadBalancerAttributes.ConnectionSettings = requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionSettings;
                requestLoadBalancerAttributesIsNull = false;
            }
            Amazon.ElasticLoadBalancing.Model.CrossZoneLoadBalancing requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing = null;
            
             // populate CrossZoneLoadBalancing
            var requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancingIsNull = true;
            requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing = new Amazon.ElasticLoadBalancing.Model.CrossZoneLoadBalancing();
            System.Boolean? requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing_crossZoneLoadBalancing_Enabled = null;
            if (cmdletContext.CrossZoneLoadBalancing_Enabled != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing_crossZoneLoadBalancing_Enabled = cmdletContext.CrossZoneLoadBalancing_Enabled.Value;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing_crossZoneLoadBalancing_Enabled != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing.Enabled = requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing_crossZoneLoadBalancing_Enabled.Value;
                requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancingIsNull = false;
            }
             // determine if requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing should be set to null
            if (requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancingIsNull)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing = null;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing != null)
            {
                request.LoadBalancerAttributes.CrossZoneLoadBalancing = requestLoadBalancerAttributes_loadBalancerAttributes_CrossZoneLoadBalancing;
                requestLoadBalancerAttributesIsNull = false;
            }
            Amazon.ElasticLoadBalancing.Model.ConnectionDraining requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining = null;
            
             // populate ConnectionDraining
            var requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDrainingIsNull = true;
            requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining = new Amazon.ElasticLoadBalancing.Model.ConnectionDraining();
            System.Boolean? requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining_connectionDraining_Enabled = null;
            if (cmdletContext.ConnectionDraining_Enabled != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining_connectionDraining_Enabled = cmdletContext.ConnectionDraining_Enabled.Value;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining_connectionDraining_Enabled != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining.Enabled = requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining_connectionDraining_Enabled.Value;
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDrainingIsNull = false;
            }
            System.Int32? requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining_connectionDraining_Timeout = null;
            if (cmdletContext.ConnectionDraining_Timeout != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining_connectionDraining_Timeout = cmdletContext.ConnectionDraining_Timeout.Value;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining_connectionDraining_Timeout != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining.Timeout = requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining_connectionDraining_Timeout.Value;
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDrainingIsNull = false;
            }
             // determine if requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining should be set to null
            if (requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDrainingIsNull)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining = null;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining != null)
            {
                request.LoadBalancerAttributes.ConnectionDraining = requestLoadBalancerAttributes_loadBalancerAttributes_ConnectionDraining;
                requestLoadBalancerAttributesIsNull = false;
            }
            Amazon.ElasticLoadBalancing.Model.AccessLog requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog = null;
            
             // populate AccessLog
            var requestLoadBalancerAttributes_loadBalancerAttributes_AccessLogIsNull = true;
            requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog = new Amazon.ElasticLoadBalancing.Model.AccessLog();
            System.Int32? requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_EmitInterval = null;
            if (cmdletContext.AccessLog_EmitInterval != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_EmitInterval = cmdletContext.AccessLog_EmitInterval.Value;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_EmitInterval != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog.EmitInterval = requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_EmitInterval.Value;
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLogIsNull = false;
            }
            System.Boolean? requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_Enabled = null;
            if (cmdletContext.AccessLog_Enabled != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_Enabled = cmdletContext.AccessLog_Enabled.Value;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_Enabled != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog.Enabled = requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_Enabled.Value;
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLogIsNull = false;
            }
            System.String requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_S3BucketName = null;
            if (cmdletContext.AccessLog_S3BucketName != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_S3BucketName = cmdletContext.AccessLog_S3BucketName;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_S3BucketName != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog.S3BucketName = requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_S3BucketName;
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLogIsNull = false;
            }
            System.String requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_S3BucketPrefix = null;
            if (cmdletContext.AccessLog_S3BucketPrefix != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_S3BucketPrefix = cmdletContext.AccessLog_S3BucketPrefix;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_S3BucketPrefix != null)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog.S3BucketPrefix = requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog_accessLog_S3BucketPrefix;
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLogIsNull = false;
            }
             // determine if requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog should be set to null
            if (requestLoadBalancerAttributes_loadBalancerAttributes_AccessLogIsNull)
            {
                requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog = null;
            }
            if (requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog != null)
            {
                request.LoadBalancerAttributes.AccessLog = requestLoadBalancerAttributes_loadBalancerAttributes_AccessLog;
                requestLoadBalancerAttributesIsNull = false;
            }
             // determine if request.LoadBalancerAttributes should be set to null
            if (requestLoadBalancerAttributesIsNull)
            {
                request.LoadBalancerAttributes = null;
            }
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
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
        
        private Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "ModifyLoadBalancerAttributes");
            try
            {
                #if DESKTOP
                return client.ModifyLoadBalancerAttributes(request);
                #elif CORECLR
                return client.ModifyLoadBalancerAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? AccessLog_EmitInterval { get; set; }
            public System.Boolean? AccessLog_Enabled { get; set; }
            public System.String AccessLog_S3BucketName { get; set; }
            public System.String AccessLog_S3BucketPrefix { get; set; }
            public List<Amazon.ElasticLoadBalancing.Model.AdditionalAttribute> LoadBalancerAttributes_AdditionalAttribute { get; set; }
            public System.Boolean? ConnectionDraining_Enabled { get; set; }
            public System.Int32? ConnectionDraining_Timeout { get; set; }
            public System.Int32? ConnectionSettings_IdleTimeout { get; set; }
            public System.Boolean? CrossZoneLoadBalancing_Enabled { get; set; }
            public System.String LoadBalancerName { get; set; }
            public System.Func<Amazon.ElasticLoadBalancing.Model.ModifyLoadBalancerAttributesResponse, EditELBLoadBalancerAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
