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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Returns a database user name and temporary password with temporary authorization to
    /// log in to Amazon Redshift Serverless.
    /// 
    ///  
    /// <para>
    /// By default, the temporary credentials expire in 900 seconds. You can optionally specify
    /// a duration between 900 seconds (15 minutes) and 3600 seconds (60 minutes).
    /// </para><pre><code> &lt;p&gt;The Identity and Access Management (IAM) user or role that runs
    /// GetCredentials must have an IAM policy attached that allows access to all necessary
    /// actions and resources.&lt;/p&gt; &lt;p&gt;If the &lt;code&gt;DbName&lt;/code&gt; parameter
    /// is specified, the IAM policy must allow access to the resource dbname for the specified
    /// database name.&lt;/p&gt; </code></pre>
    /// </summary>
    [Cmdlet("Get", "RSSCredential")]
    [OutputType("Amazon.RedshiftServerless.Model.GetCredentialsResponse")]
    [AWSCmdlet("Calls the Redshift Serverless GetCredentials API operation.", Operation = new[] {"GetCredentials"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.GetCredentialsResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.GetCredentialsResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.GetCredentialsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRSSCredentialCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomDomainName
        /// <summary>
        /// <para>
        /// <para>The custom domain name associated with the workgroup. The custom domain name or the
        /// workgroup name must be included in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDomainName { get; set; }
        #endregion
        
        #region Parameter DbName
        /// <summary>
        /// <para>
        /// <para>The name of the database to get temporary authorization to log on to.</para><para>Constraints:</para><ul><li><para>Must be 1 to 64 alphanumeric characters or hyphens.</para></li><li><para>Must contain only uppercase or lowercase letters, numbers, underscore, plus sign,
        /// period (dot), at symbol (@), or hyphen.</para></li><li><para>The first character must be a letter.</para></li><li><para>Must not contain a colon ( : ) or slash ( / ).</para></li><li><para>Cannot be a reserved word. A list of reserved words can be found in <a href="https://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words </a> in the Amazon Redshift Database Developer Guide</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbName { get; set; }
        #endregion
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds until the returned temporary password expires. The minimum is
        /// 900 seconds, and the maximum is 3600 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The name of the workgroup associated with the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String WorkgroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.GetCredentialsResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.GetCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkgroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkgroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkgroupName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.GetCredentialsResponse, GetRSSCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkgroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomDomainName = this.CustomDomainName;
            context.DbName = this.DbName;
            context.DurationSecond = this.DurationSecond;
            context.WorkgroupName = this.WorkgroupName;
            
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
            var request = new Amazon.RedshiftServerless.Model.GetCredentialsRequest();
            
            if (cmdletContext.CustomDomainName != null)
            {
                request.CustomDomainName = cmdletContext.CustomDomainName;
            }
            if (cmdletContext.DbName != null)
            {
                request.DbName = cmdletContext.DbName;
            }
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
            }
            if (cmdletContext.WorkgroupName != null)
            {
                request.WorkgroupName = cmdletContext.WorkgroupName;
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
        
        private Amazon.RedshiftServerless.Model.GetCredentialsResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.GetCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "GetCredentials");
            try
            {
                #if DESKTOP
                return client.GetCredentials(request);
                #elif CORECLR
                return client.GetCredentialsAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomDomainName { get; set; }
            public System.String DbName { get; set; }
            public System.Int32? DurationSecond { get; set; }
            public System.String WorkgroupName { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.GetCredentialsResponse, GetRSSCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
