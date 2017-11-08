/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates one or more Amazon Lightsail virtual private servers, or <i>instances</i>.
    /// </summary>
    [Cmdlet("New", "LSInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateInstances API operation.", Operation = new[] {"CreateInstances"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSInstanceCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create your instance. Use the following format:
        /// <code>us-east-1a</code> (case sensitive). You can get a list of availability zones
        /// by using the <a href="http://docs.aws.amazon.com/lightsail/2016-11-28/api-reference/API_GetRegions.html">get
        /// regions</a> operation. Be sure to add the <code>include availability zones</code>
        /// parameter to your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BlueprintId
        /// <summary>
        /// <para>
        /// <para>The ID for a virtual private server image (e.g., <code>app_wordpress_4_4</code> or
        /// <code>app_lamp_7_0</code>). Use the get blueprints operation to return a list of available
        /// images (or <i>blueprints</i>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BlueprintId { get; set; }
        #endregion
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>The bundle of specification information for your virtual private server (or <i>instance</i>),
        /// including the pricing plan (e.g., <code>micro_1_0</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BundleId { get; set; }
        #endregion
        
        #region Parameter CustomImageName
        /// <summary>
        /// <para>
        /// <para>(Deprecated) The name for your custom image.</para><note><para>In releases prior to June 12, 2017, this parameter was ignored by the API. It is now
        /// deprecated.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomImageName { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The names to use for your new Lightsail instances. Separate multiple values using
        /// quotation marks and commas, for example: <code>["MyFirstInstance","MySecondInstance"]</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("InstanceNames")]
        public System.String[] InstanceName { get; set; }
        #endregion
        
        #region Parameter KeyPairName
        /// <summary>
        /// <para>
        /// <para>The name of your key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyPairName { get; set; }
        #endregion
        
        #region Parameter UserData
        /// <summary>
        /// <para>
        /// <para>A launch script you can create that configures a server with additional user data.
        /// For example, you might want to run <code>apt-get –y update</code>.</para><note><para>Depending on the machine image you choose, the command to get software on your instance
        /// varies. Amazon Linux and CentOS use <code>yum</code>, Debian and Ubuntu use <code>apt-get</code>,
        /// and FreeBSD uses <code>pkg</code>. For a complete list, see the <a href="https://lightsail.aws.amazon.com/ls/docs/getting-started/article/compare-options-choose-lightsail-instance-image">Dev
        /// Guide</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UserData { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSInstance (CreateInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AvailabilityZone = this.AvailabilityZone;
            context.BlueprintId = this.BlueprintId;
            context.BundleId = this.BundleId;
            context.CustomImageName = this.CustomImageName;
            if (this.InstanceName != null)
            {
                context.InstanceNames = new List<System.String>(this.InstanceName);
            }
            context.KeyPairName = this.KeyPairName;
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
            if (cmdletContext.CustomImageName != null)
            {
                request.CustomImageName = cmdletContext.CustomImageName;
            }
            if (cmdletContext.InstanceNames != null)
            {
                request.InstanceNames = cmdletContext.InstanceNames;
            }
            if (cmdletContext.KeyPairName != null)
            {
                request.KeyPairName = cmdletContext.KeyPairName;
            }
            if (cmdletContext.UserData != null)
            {
                request.UserData = cmdletContext.UserData;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Operations;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateInstancesAsync(request);
                return task.Result;
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
            public System.String AvailabilityZone { get; set; }
            public System.String BlueprintId { get; set; }
            public System.String BundleId { get; set; }
            public System.String CustomImageName { get; set; }
            public List<System.String> InstanceNames { get; set; }
            public System.String KeyPairName { get; set; }
            public System.String UserData { get; set; }
        }
        
    }
}
