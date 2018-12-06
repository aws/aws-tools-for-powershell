/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Uses a specific snapshot as a blueprint for creating one or more new instances that
    /// are based on that identical configuration.
    /// 
    ///  
    /// <para>
    /// The <code>create instances from snapshot</code> operation supports tag-based access
    /// control via request tags and resource tags applied to the resource identified by instanceSnapshotName.
    /// For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en/articles/amazon-lightsail-controlling-access-using-tags">Lightsail
    /// Dev Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSInstancesFromSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateInstancesFromSnapshot API operation.", Operation = new[] {"CreateInstancesFromSnapshot"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateInstancesFromSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSInstancesFromSnapshotCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter AttachedDiskMapping
        /// <summary>
        /// <para>
        /// <para>An object containing information about one or more disk mappings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AttachedDiskMapping { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone where you want to create your instances. Use the following formatting:
        /// <code>us-east-2a</code> (case sensitive). You can get a list of Availability Zones
        /// by using the <a href="http://docs.aws.amazon.com/lightsail/2016-11-28/api-reference/API_GetRegions.html">get
        /// regions</a> operation. Be sure to add the <code>include Availability Zones</code>
        /// parameter to your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
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
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The names for your new instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("InstanceNames")]
        public System.String[] InstanceName { get; set; }
        #endregion
        
        #region Parameter InstanceSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the instance snapshot on which you are basing your new instances. Use
        /// the get instance snapshots operation to return information about your existing snapshots.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceSnapshotName { get; set; }
        #endregion
        
        #region Parameter KeyPairName
        /// <summary>
        /// <para>
        /// <para>The name for your key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyPairName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the resource during create.</para><para>To tag a resource after it has been created, see the <code>tag resource</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UserData
        /// <summary>
        /// <para>
        /// <para>You can create a launch script that configures a server with additional user data.
        /// For example, <code>apt-get -y update</code>.</para><note><para>Depending on the machine image you choose, the command to get software on your instance
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSInstancesFromSnapshot (CreateInstancesFromSnapshot)"))
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
            
            if (this.AttachedDiskMapping != null)
            {
                context.AttachedDiskMapping = new Dictionary<System.String, List<Amazon.Lightsail.Model.DiskMap>>(StringComparer.Ordinal);
                foreach (var hashKey in this.AttachedDiskMapping.Keys)
                {
                    object hashValue = this.AttachedDiskMapping[hashKey];
                    if (hashValue == null)
                    {
                        context.AttachedDiskMapping.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<DiskMap>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((DiskMap)s);
                    }
                    context.AttachedDiskMapping.Add((String)hashKey, valueSet);
                }
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.BundleId = this.BundleId;
            if (this.InstanceName != null)
            {
                context.InstanceNames = new List<System.String>(this.InstanceName);
            }
            context.InstanceSnapshotName = this.InstanceSnapshotName;
            context.KeyPairName = this.KeyPairName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
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
            var request = new Amazon.Lightsail.Model.CreateInstancesFromSnapshotRequest();
            
            if (cmdletContext.AttachedDiskMapping != null)
            {
                request.AttachedDiskMapping = cmdletContext.AttachedDiskMapping;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.BundleId != null)
            {
                request.BundleId = cmdletContext.BundleId;
            }
            if (cmdletContext.InstanceNames != null)
            {
                request.InstanceNames = cmdletContext.InstanceNames;
            }
            if (cmdletContext.InstanceSnapshotName != null)
            {
                request.InstanceSnapshotName = cmdletContext.InstanceSnapshotName;
            }
            if (cmdletContext.KeyPairName != null)
            {
                request.KeyPairName = cmdletContext.KeyPairName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
        
        private Amazon.Lightsail.Model.CreateInstancesFromSnapshotResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateInstancesFromSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateInstancesFromSnapshot");
            try
            {
                #if DESKTOP
                return client.CreateInstancesFromSnapshot(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateInstancesFromSnapshotAsync(request);
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
            public Dictionary<System.String, List<Amazon.Lightsail.Model.DiskMap>> AttachedDiskMapping { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.String BundleId { get; set; }
            public List<System.String> InstanceNames { get; set; }
            public System.String InstanceSnapshotName { get; set; }
            public System.String KeyPairName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tags { get; set; }
            public System.String UserData { get; set; }
        }
        
    }
}
