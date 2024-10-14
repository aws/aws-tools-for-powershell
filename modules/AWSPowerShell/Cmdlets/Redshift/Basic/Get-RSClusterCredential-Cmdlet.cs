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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Returns a database user name and temporary password with temporary authorization to
    /// log on to an Amazon Redshift database. The action returns the database user name prefixed
    /// with <c>IAM:</c> if <c>AutoCreate</c> is <c>False</c> or <c>IAMA:</c> if <c>AutoCreate</c>
    /// is <c>True</c>. You can optionally specify one or more database user groups that the
    /// user will join at log on. By default, the temporary credentials expire in 900 seconds.
    /// You can optionally specify a duration between 900 seconds (15 minutes) and 3600 seconds
    /// (60 minutes). For more information, see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/generating-user-credentials.html">Using
    /// IAM Authentication to Generate Database User Credentials</a> in the Amazon Redshift
    /// Cluster Management Guide.
    /// 
    ///  
    /// <para>
    /// The Identity and Access Management (IAM) user or role that runs GetClusterCredentials
    /// must have an IAM policy attached that allows access to all necessary actions and resources.
    /// For more information about permissions, see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/redshift-iam-access-control-identity-based.html#redshift-policy-resources.getclustercredentials-resources">Resource
    /// Policies for GetClusterCredentials</a> in the Amazon Redshift Cluster Management Guide.
    /// </para><para>
    /// If the <c>DbGroups</c> parameter is specified, the IAM policy must allow the <c>redshift:JoinGroup</c>
    /// action with access to the listed <c>dbgroups</c>. 
    /// </para><para>
    /// In addition, if the <c>AutoCreate</c> parameter is set to <c>True</c>, then the policy
    /// must include the <c>redshift:CreateClusterUser</c> permission.
    /// </para><para>
    /// If the <c>DbName</c> parameter is specified, the IAM policy must allow access to the
    /// resource <c>dbname</c> for the specified database name. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RSClusterCredential")]
    [OutputType("Amazon.Redshift.Model.GetClusterCredentialsResponse")]
    [AWSCmdlet("Calls the Amazon Redshift GetClusterCredentials API operation.", Operation = new[] {"GetClusterCredentials"}, SelectReturnType = typeof(Amazon.Redshift.Model.GetClusterCredentialsResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.GetClusterCredentialsResponse",
        "This cmdlet returns an Amazon.Redshift.Model.GetClusterCredentialsResponse object containing multiple properties."
    )]
    public partial class GetRSClusterCredentialCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoCreate
        /// <summary>
        /// <para>
        /// <para>Create a database user with the name specified for the user named in <c>DbUser</c>
        /// if one does not exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoCreate { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster that contains the database for which you are
        /// requesting credentials. This parameter is case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter CustomDomainName
        /// <summary>
        /// <para>
        /// <para>The custom domain name for the cluster credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDomainName { get; set; }
        #endregion
        
        #region Parameter DbGroup
        /// <summary>
        /// <para>
        /// <para>A list of the names of existing database groups that the user named in <c>DbUser</c>
        /// will join for the current session, in addition to any group memberships for an existing
        /// user. If not specified, a new user is added only to PUBLIC.</para><para>Database group name constraints</para><ul><li><para>Must be 1 to 64 alphanumeric characters or hyphens</para></li><li><para>Must contain only lowercase letters, numbers, underscore, plus sign, period (dot),
        /// at symbol (@), or hyphen.</para></li><li><para>First character must be a letter.</para></li><li><para>Must not contain a colon ( : ) or slash ( / ). </para></li><li><para>Cannot be a reserved word. A list of reserved words can be found in <a href="http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words</a> in the Amazon Redshift Database Developer Guide.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DbGroups")]
        public System.String[] DbGroup { get; set; }
        #endregion
        
        #region Parameter DbName
        /// <summary>
        /// <para>
        /// <para>The name of a database that <c>DbUser</c> is authorized to log on to. If <c>DbName</c>
        /// is not specified, <c>DbUser</c> can log on to any existing database.</para><para>Constraints:</para><ul><li><para>Must be 1 to 64 alphanumeric characters or hyphens</para></li><li><para>Must contain uppercase or lowercase letters, numbers, underscore, plus sign, period
        /// (dot), at symbol (@), or hyphen.</para></li><li><para>First character must be a letter.</para></li><li><para>Must not contain a colon ( : ) or slash ( / ). </para></li><li><para>Cannot be a reserved word. A list of reserved words can be found in <a href="http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words</a> in the Amazon Redshift Database Developer Guide.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbName { get; set; }
        #endregion
        
        #region Parameter DbUser
        /// <summary>
        /// <para>
        /// <para>The name of a database user. If a user name matching <c>DbUser</c> exists in the database,
        /// the temporary user credentials have the same permissions as the existing user. If
        /// <c>DbUser</c> doesn't exist in the database and <c>Autocreate</c> is <c>True</c>,
        /// a new user is created using the value for <c>DbUser</c> with PUBLIC permissions. If
        /// a database user matching the value for <c>DbUser</c> doesn't exist and <c>Autocreate</c>
        /// is <c>False</c>, then the command succeeds but the connection attempt will fail because
        /// the user doesn't exist in the database.</para><para>For more information, see <a href="https://docs.aws.amazon.com/redshift/latest/dg/r_CREATE_USER.html">CREATE
        /// USER</a> in the Amazon Redshift Database Developer Guide. </para><para>Constraints:</para><ul><li><para>Must be 1 to 64 alphanumeric characters or hyphens. The user name can't be <c>PUBLIC</c>.</para></li><li><para>Must contain uppercase or lowercase letters, numbers, underscore, plus sign, period
        /// (dot), at symbol (@), or hyphen.</para></li><li><para>First character must be a letter.</para></li><li><para>Must not contain a colon ( : ) or slash ( / ). </para></li><li><para>Cannot be a reserved word. A list of reserved words can be found in <a href="http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words</a> in the Amazon Redshift Database Developer Guide.</para></li></ul>
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
        public System.String DbUser { get; set; }
        #endregion
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds until the returned temporary password expires.</para><para>Constraint: minimum 900, maximum 3600.</para><para>Default: 900</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.GetClusterCredentialsResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.GetClusterCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.GetClusterCredentialsResponse, GetRSClusterCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoCreate = this.AutoCreate;
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.CustomDomainName = this.CustomDomainName;
            if (this.DbGroup != null)
            {
                context.DbGroup = new List<System.String>(this.DbGroup);
            }
            context.DbName = this.DbName;
            context.DbUser = this.DbUser;
            #if MODULAR
            if (this.DbUser == null && ParameterWasBound(nameof(this.DbUser)))
            {
                WriteWarning("You are passing $null as a value for parameter DbUser which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DurationSecond = this.DurationSecond;
            
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
            if (cmdletContext.CustomDomainName != null)
            {
                request.CustomDomainName = cmdletContext.CustomDomainName;
            }
            if (cmdletContext.DbGroup != null)
            {
                request.DbGroups = cmdletContext.DbGroup;
            }
            if (cmdletContext.DbName != null)
            {
                request.DbName = cmdletContext.DbName;
            }
            if (cmdletContext.DbUser != null)
            {
                request.DbUser = cmdletContext.DbUser;
            }
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
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
            public System.String CustomDomainName { get; set; }
            public List<System.String> DbGroup { get; set; }
            public System.String DbName { get; set; }
            public System.String DbUser { get; set; }
            public System.Int32? DurationSecond { get; set; }
            public System.Func<Amazon.Redshift.Model.GetClusterCredentialsResponse, GetRSClusterCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
