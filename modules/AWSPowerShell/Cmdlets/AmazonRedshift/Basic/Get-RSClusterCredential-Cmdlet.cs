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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Returns a database user name and temporary password with temporary authorization to
    /// log on to an Amazon Redshift database. The action returns the database user name prefixed
    /// with <code>IAM:</code> if <code>AutoCreate</code> is <code>False</code> or <code>IAMA:</code>
    /// if <code>AutoCreate</code> is <code>True</code>. You can optionally specify one or
    /// more database user groups that the user will join at log on. By default, the temporary
    /// credentials expire in 900 seconds. You can optionally specify a duration between 900
    /// seconds (15 minutes) and 3600 seconds (60 minutes). For more information, see <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/generating-user-credentials.html">Using
    /// IAM Authentication to Generate Database User Credentials</a> in the Amazon Redshift
    /// Cluster Management Guide.
    /// 
    ///  
    /// <para>
    /// The AWS Identity and Access Management (IAM)user or role that executes GetClusterCredentials
    /// must have an IAM policy attached that allows access to all necessary actions and resources.
    /// For more information about permissions, see <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/redshift-iam-access-control-identity-based.html#redshift-policy-resources.getclustercredentials-resources">Resource
    /// Policies for GetClusterCredentials</a> in the Amazon Redshift Cluster Management Guide.
    /// </para><para>
    /// If the <code>DbGroups</code> parameter is specified, the IAM policy must allow the
    /// <code>redshift:JoinGroup</code> action with access to the listed <code>dbgroups</code>.
    /// 
    /// </para><para>
    /// In addition, if the <code>AutoCreate</code> parameter is set to <code>True</code>,
    /// then the policy must include the <code>redshift:CreateClusterUser</code> privilege.
    /// </para><para>
    /// If the <code>DbName</code> parameter is specified, the IAM policy must allow access
    /// to the resource <code>dbname</code> for the specified database name. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RSClusterCredential")]
    [OutputType("Amazon.Redshift.Model.GetClusterCredentialsResponse")]
    [AWSCmdlet("Calls the Amazon Redshift GetClusterCredentials API operation.", Operation = new[] {"GetClusterCredentials"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.GetClusterCredentialsResponse",
        "This cmdlet returns a Amazon.Redshift.Model.GetClusterCredentialsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRSClusterCredentialCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter AutoCreate
        /// <summary>
        /// <para>
        /// <para>Create a database user with the name specified for the user named in <code>DbUser</code>
        /// if one does not exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoCreate { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster that contains the database for which your are
        /// requesting credentials. This parameter is case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DbGroup
        /// <summary>
        /// <para>
        /// <para>A list of the names of existing database groups that the user named in <code>DbUser</code>
        /// will join for the current session, in addition to any group memberships for an existing
        /// user. If not specified, a new user is added only to PUBLIC.</para><para>Database group name constraints</para><ul><li><para>Must be 1 to 64 alphanumeric characters or hyphens</para></li><li><para>Must contain only lowercase letters, numbers, underscore, plus sign, period (dot),
        /// at symbol (@), or hyphen.</para></li><li><para>First character must be a letter.</para></li><li><para>Must not contain a colon ( : ) or slash ( / ). </para></li><li><para>Cannot be a reserved word. A list of reserved words can be found in <a href="http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words</a> in the Amazon Redshift Database Developer Guide.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DbGroups")]
        public System.String[] DbGroup { get; set; }
        #endregion
        
        #region Parameter DbName
        /// <summary>
        /// <para>
        /// <para>The name of a database that <code>DbUser</code> is authorized to log on to. If <code>DbName</code>
        /// is not specified, <code>DbUser</code> can log on to any existing database.</para><para>Constraints:</para><ul><li><para>Must be 1 to 64 alphanumeric characters or hyphens</para></li><li><para>Must contain only lowercase letters, numbers, underscore, plus sign, period (dot),
        /// at symbol (@), or hyphen.</para></li><li><para>First character must be a letter.</para></li><li><para>Must not contain a colon ( : ) or slash ( / ). </para></li><li><para>Cannot be a reserved word. A list of reserved words can be found in <a href="http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words</a> in the Amazon Redshift Database Developer Guide.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DbName { get; set; }
        #endregion
        
        #region Parameter DbUser
        /// <summary>
        /// <para>
        /// <para>The name of a database user. If a user name matching <code>DbUser</code> exists in
        /// the database, the temporary user credentials have the same permissions as the existing
        /// user. If <code>DbUser</code> doesn't exist in the database and <code>Autocreate</code>
        /// is <code>True</code>, a new user is created using the value for <code>DbUser</code>
        /// with PUBLIC permissions. If a database user matching the value for <code>DbUser</code>
        /// doesn't exist and <code>Autocreate</code> is <code>False</code>, then the command
        /// succeeds but the connection attempt will fail because the user doesn't exist in the
        /// database.</para><para>For more information, see <a href="http://docs.aws.amazon.com/redshift/latest/dg/r_CREATE_USER.html">CREATE
        /// USER</a> in the Amazon Redshift Database Developer Guide. </para><para>Constraints:</para><ul><li><para>Must be 1 to 64 alphanumeric characters or hyphens. The user name can't be <code>PUBLIC</code>.</para></li><li><para>Must contain only lowercase letters, numbers, underscore, plus sign, period (dot),
        /// at symbol (@), or hyphen.</para></li><li><para>First character must be a letter.</para></li><li><para>Must not contain a colon ( : ) or slash ( / ). </para></li><li><para>Cannot be a reserved word. A list of reserved words can be found in <a href="http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words</a> in the Amazon Redshift Database Developer Guide.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DbUser { get; set; }
        #endregion
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds until the returned temporary password expires.</para><para>Constraint: minimum 900, maximum 3600.</para><para>Default: 900</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DurationSeconds")]
        public System.Int32 DurationSecond { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("AutoCreate"))
                context.AutoCreate = this.AutoCreate;
            context.ClusterIdentifier = this.ClusterIdentifier;
            if (this.DbGroup != null)
            {
                context.DbGroups = new List<System.String>(this.DbGroup);
            }
            context.DbName = this.DbName;
            context.DbUser = this.DbUser;
            if (ParameterWasBound("DurationSecond"))
                context.DurationSeconds = this.DurationSecond;
            
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
            var request = new Amazon.Redshift.Model.GetClusterCredentialsRequest();
            
            if (cmdletContext.AutoCreate != null)
            {
                request.AutoCreate = cmdletContext.AutoCreate.Value;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.DbGroups != null)
            {
                request.DbGroups = cmdletContext.DbGroups;
            }
            if (cmdletContext.DbName != null)
            {
                request.DbName = cmdletContext.DbName;
            }
            if (cmdletContext.DbUser != null)
            {
                request.DbUser = cmdletContext.DbUser;
            }
            if (cmdletContext.DurationSeconds != null)
            {
                request.DurationSeconds = cmdletContext.DurationSeconds.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Redshift.Model.GetClusterCredentialsResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.GetClusterCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "GetClusterCredentials");
            try
            {
                #if DESKTOP
                return client.GetClusterCredentials(request);
                #elif CORECLR
                return client.GetClusterCredentialsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AutoCreate { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public List<System.String> DbGroups { get; set; }
            public System.String DbName { get; set; }
            public System.String DbUser { get; set; }
            public System.Int32? DurationSeconds { get; set; }
        }
        
    }
}
