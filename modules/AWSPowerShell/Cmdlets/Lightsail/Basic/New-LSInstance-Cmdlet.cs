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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates one or more Amazon Lightsail instances.
    /// 
    ///  
    /// <para>
    /// The <code>create instances</code> operation supports tag-based access control via
    /// request tags. For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en/articles/amazon-lightsail-controlling-access-using-tags">Lightsail
    /// Dev Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateInstances API operation.", Operation = new[] {"CreateInstances"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateInstancesResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.CreateInstancesResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSInstanceCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter AddOn
        /// <summary>
        /// <para>
        /// <para>An array of objects representing the add-ons to enable for the new instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddOns")]
        public Amazon.Lightsail.Model.AddOnRequest[] AddOn { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create your instance. Use the following format:
        /// <code>us-east-2a</code> (case sensitive). You can get a list of Availability Zones
        /// by using the <a href="http://docs.aws.amazon.com/lightsail/2016-11-28/api-reference/API_GetRegions.html">get
        /// regions</a> operation. Be sure to add the <code>include Availability Zones</code>
        /// parameter to your request.</para>
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
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BlueprintId
        /// <summary>
        /// <para>
        /// <para>The ID for a virtual private server image (e.g., <code>app_wordpress_4_4</code> or
        /// <code>app_lamp_7_0</code>). Use the <code>get blueprints</code> operation to return
        /// a list of available images (or <i>blueprints</i>).</para><note><para>Use active blueprints when creating new instances. Inactive blueprints are listed
        /// to support customers with existing instances and are not necessarily available to
        /// create new instances. Blueprints are marked inactive when they become outdated due
        /// to operating system updates or new application releases.</para></note>
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
        public System.String BlueprintId { get; set; }
        #endregion
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>The bundle of specification information for your virtual private server (or <i>instance</i>),
        /// including the pricing plan (e.g., <code>micro_1_0</code>).</para>
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
        public System.String BundleId { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The names to use for your new Lightsail instances. Separate multiple values using
        /// quotation marks and commas, for example: <code>["MyFirstInstance","MySecondInstance"]</code></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstanceNames")]
        public System.String[] InstanceName { get; set; }
        #endregion
        
        #region Parameter KeyPairName
        /// <summary>
        /// <para>
        /// <para>The name of your key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyPairName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the resource during create.</para><para>Use the <code>TagResource</code> action to tag a resource after it's created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UserData
        /// <summary>
        /// <para>
        /// <para>A launch script you can create that configures a server with additional user data.
        /// For example, you might want to run <code>apt-get -y update</code>.</para><note><para>Depending on the machine image you choose, the command to get software on your instance
        /// varies. Amazon Linux and CentOS use <code>yum</code>, Debian and Ubuntu use <code>apt-get</code>,
        /// and FreeBSD uses <code>pkg</code>. For a complete list, see the <a href="https://lightsail.aws.amazon.com/ls/docs/getting-started/article/compare-options-choose-lightsail-instance-image">Dev
        /// Guide</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserData { get; set; }
        #endregion
        
        #region Parameter CustomImageName
        /// <summary>
        /// <para>
        /// <para>(Deprecated) The name for your custom image.</para><note><para>In releases prior to June 12, 2017, this parameter was ignored by the API. It is now
        /// deprecated.</para></note>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("In releases prior to June 12, 2017, this parameter was ignored by the API. It is now deprecated.")]
        public System.String CustomImageName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateInstancesResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSInstance (CreateInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateInstancesResponse, NewLSInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddOn != null)
            {
                context.AddOn = new List<Amazon.Lightsail.Model.AddOnRequest>(this.AddOn);
            }
            context.AvailabilityZone = this.AvailabilityZone;
            #if MODULAR
            if (this.AvailabilityZone == null && ParameterWasBound(nameof(this.AvailabilityZone)))
            {
                WriteWarning("You are passing $null as a value for parameter AvailabilityZone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BlueprintId = this.BlueprintId;
            #if MODULAR
            if (this.BlueprintId == null && ParameterWasBound(nameof(this.BlueprintId)))
            {
                WriteWarning("You are passing $null as a value for parameter BlueprintId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BundleId = this.BundleId;
            #if MODULAR
            if (this.BundleId == null && ParameterWasBound(nameof(this.BundleId)))
            {
                WriteWarning("You are passing $null as a value for parameter BundleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomImageName = this.CustomImageName;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.InstanceName != null)
            {
                context.InstanceName = new List<System.String>(this.InstanceName);
            }
            #if MODULAR
            if (this.InstanceName == null && ParameterWasBound(nameof(this.InstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyPairName = this.KeyPairName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
            }
            context.UserData = this.UserData;
            
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
            var request = new Amazon.Lightsail.Model.CreateInstancesRequest();
            
            if (cmdletContext.AddOn != null)
            {
                request.AddOns = cmdletContext.AddOn;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.BlueprintId != null)
            {
                request.BlueprintId = cmdletContext.BlueprintId;
            }
            if (cmdletContext.BundleId != null)
            {
                request.BundleId = cmdletContext.BundleId;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.CustomImageName != null)
            {
                request.CustomImageName = cmdletContext.CustomImageName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceNames = cmdletContext.InstanceName;
            }
            if (cmdletContext.KeyPairName != null)
            {
                request.KeyPairName = cmdletContext.KeyPairName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserData != null)
            {
                request.UserData = cmdletContext.UserData;
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
        
        private Amazon.Lightsail.Model.CreateInstancesResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateInstances");
            try
            {
                #if DESKTOP
                return client.CreateInstances(request);
                #elif CORECLR
                return client.CreateInstancesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Lightsail.Model.AddOnRequest> AddOn { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.String BlueprintId { get; set; }
            public System.String BundleId { get; set; }
            [System.ObsoleteAttribute]
            public System.String CustomImageName { get; set; }
            public List<System.String> InstanceName { get; set; }
            public System.String KeyPairName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tag { get; set; }
            public System.String UserData { get; set; }
            public System.Func<Amazon.Lightsail.Model.CreateInstancesResponse, NewLSInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
