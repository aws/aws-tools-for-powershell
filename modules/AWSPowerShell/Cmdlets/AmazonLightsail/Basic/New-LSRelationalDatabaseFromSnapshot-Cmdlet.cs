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
    /// Creates a new database from an existing database snapshot in Amazon Lightsail.
    /// 
    ///  
    /// <para>
    /// You can create a new database from a snapshot in if something goes wrong with your
    /// original database, or to change it to a different plan, such as a high availability
    /// or standard plan.
    /// </para><para>
    /// The <code>create relational database from snapshot</code> operation supports tag-based
    /// access control via request tags and resource tags applied to the resource identified
    /// by relationalDatabaseSnapshotName. For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en/articles/amazon-lightsail-controlling-access-using-tags">Lightsail
    /// Dev Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSRelationalDatabaseFromSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateRelationalDatabaseFromSnapshot API operation.", Operation = new[] {"CreateRelationalDatabaseFromSnapshot"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateRelationalDatabaseFromSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSRelationalDatabaseFromSnapshotCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create your new database. Use the <code>us-east-2a</code>
        /// case-sensitive format.</para><para>You can get a list of Availability Zones by using the <code>get regions</code> operation.
        /// Be sure to add the <code>include relational database Availability Zones</code> parameter
        /// to your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies the accessibility options for your new database. A value of <code>true</code>
        /// specifies a database that is available to resources outside of your Lightsail account.
        /// A value of <code>false</code> specifies a database that is available only to your
        /// Lightsail resources in the same region as your database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseBundleId
        /// <summary>
        /// <para>
        /// <para>The bundle ID for your new database. A bundle describes the performance specifications
        /// for your database.</para><para>You can get a list of database bundle IDs by using the <code>get relational database
        /// bundles</code> operation.</para><para>When creating a new database from a snapshot, you cannot choose a bundle that is smaller
        /// than the bundle of the source database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RelationalDatabaseBundleId { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name to use for your new database.</para><para>Constraints:</para><ul><li><para>Must contain from 2 to 255 alphanumeric characters, or hyphens.</para></li><li><para>The first and last character must be a letter or number.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the database snapshot from which to create your new database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RelationalDatabaseSnapshotName { get; set; }
        #endregion
        
        #region Parameter RestoreTime
        /// <summary>
        /// <para>
        /// <para>The date and time to restore your database from.</para><para>Constraints:</para><ul><li><para>Must be before the latest restorable time for the database.</para></li><li><para>Cannot be specified if the <code>use latest restorable time</code> parameter is <code>true</code>.</para></li><li><para>Specified in Universal Coordinated Time (UTC).</para></li><li><para>Specified in the Unix time format.</para><para>For example, if you wish to use a restore time of October 1, 2018, at 8 PM UTC, then
        /// you input <code>1538424000</code> as the restore time.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime RestoreTime { get; set; }
        #endregion
        
        #region Parameter SourceRelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the source database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceRelationalDatabaseName { get; set; }
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
        
        #region Parameter UseLatestRestorableTime
        /// <summary>
        /// <para>
        /// <para>Specifies whether your database is restored from the latest backup time. A value of
        /// <code>true</code> restores from the latest backup time. </para><para>Default: <code>false</code></para><para>Constraints: Cannot be specified if the <code>restore time</code> parameter is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UseLatestRestorableTime { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RelationalDatabaseName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSRelationalDatabaseFromSnapshot (CreateRelationalDatabaseFromSnapshot)"))
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
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.RelationalDatabaseBundleId = this.RelationalDatabaseBundleId;
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            context.RelationalDatabaseSnapshotName = this.RelationalDatabaseSnapshotName;
            if (ParameterWasBound("RestoreTime"))
                context.RestoreTime = this.RestoreTime;
            context.SourceRelationalDatabaseName = this.SourceRelationalDatabaseName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
            }
            if (ParameterWasBound("UseLatestRestorableTime"))
                context.UseLatestRestorableTime = this.UseLatestRestorableTime;
            
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
            var request = new Amazon.Lightsail.Model.CreateRelationalDatabaseFromSnapshotRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.RelationalDatabaseBundleId != null)
            {
                request.RelationalDatabaseBundleId = cmdletContext.RelationalDatabaseBundleId;
            }
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
            }
            if (cmdletContext.RelationalDatabaseSnapshotName != null)
            {
                request.RelationalDatabaseSnapshotName = cmdletContext.RelationalDatabaseSnapshotName;
            }
            if (cmdletContext.RestoreTime != null)
            {
                request.RestoreTime = cmdletContext.RestoreTime.Value;
            }
            if (cmdletContext.SourceRelationalDatabaseName != null)
            {
                request.SourceRelationalDatabaseName = cmdletContext.SourceRelationalDatabaseName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.UseLatestRestorableTime != null)
            {
                request.UseLatestRestorableTime = cmdletContext.UseLatestRestorableTime.Value;
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
        
        private Amazon.Lightsail.Model.CreateRelationalDatabaseFromSnapshotResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateRelationalDatabaseFromSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateRelationalDatabaseFromSnapshot");
            try
            {
                #if DESKTOP
                return client.CreateRelationalDatabaseFromSnapshot(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateRelationalDatabaseFromSnapshotAsync(request);
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
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String RelationalDatabaseBundleId { get; set; }
            public System.String RelationalDatabaseName { get; set; }
            public System.String RelationalDatabaseSnapshotName { get; set; }
            public System.DateTime? RestoreTime { get; set; }
            public System.String SourceRelationalDatabaseName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tags { get; set; }
            public System.Boolean? UseLatestRestorableTime { get; set; }
        }
        
    }
}
