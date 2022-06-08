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
    /// log in to an Amazon Redshift database. The database user is mapped 1:1 to the source
    /// Identity and Access Management (IAM) identity. For more information about IAM identities,
    /// see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id.html">IAM Identities
    /// (users, user groups, and roles)</a> in the Amazon Web Services Identity and Access
    /// Management User Guide.
    /// 
    ///  
    /// <para>
    /// The Identity and Access Management (IAM) identity that runs this operation must have
    /// an IAM policy attached that allows access to all necessary actions and resources.
    /// For more information about permissions, see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/redshift-iam-access-control-identity-based.html">Using
    /// identity-based policies (IAM policies)</a> in the Amazon Redshift Cluster Management
    /// Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RSClusterCredentialsWithIAM")]
    [OutputType("Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse")]
    [AWSCmdlet("Calls the Amazon Redshift GetClusterCredentialsWithIAM API operation.", Operation = new[] {"GetClusterCredentialsWithIAM"}, SelectReturnType = typeof(Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse",
        "This cmdlet returns an Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRSClusterCredentialsWithIAMCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster that contains the database for which you are
        /// requesting credentials. </para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DbName
        /// <summary>
        /// <para>
        /// <para>The name of the database for which you are requesting credentials. If the database
        /// name is specified, the IAM policy must allow access to the resource <code>dbname</code>
        /// for the specified database name. If the database name is not specified, access to
        /// all databases is allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbName { get; set; }
        #endregion
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds until the returned temporary password expires.</para><para>Range: 900-3600. Default: 900.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse, GetRSClusterCredentialsWithIAMCmdlet>(Select) ??
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
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DbName = this.DbName;
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
            var request = new Amazon.Redshift.Model.GetClusterCredentialsWithIAMRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.DbName != null)
            {
                request.DbName = cmdletContext.DbName;
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
        
        private Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.GetClusterCredentialsWithIAMRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "GetClusterCredentialsWithIAM");
            try
            {
                #if DESKTOP
                return client.GetClusterCredentialsWithIAM(request);
                #elif CORECLR
                return client.GetClusterCredentialsWithIAMAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
            public System.String DbName { get; set; }
            public System.Int32? DurationSecond { get; set; }
            public System.Func<Amazon.Redshift.Model.GetClusterCredentialsWithIAMResponse, GetRSClusterCredentialsWithIAMCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
