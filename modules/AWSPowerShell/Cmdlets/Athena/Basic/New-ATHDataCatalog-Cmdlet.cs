/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Athena;
using Amazon.Athena.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Creates (registers) a data catalog with the specified name and properties. Catalogs
    /// created are visible to all users of the same Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// For a <c>FEDERATED</c> catalog, this API operation creates the following resources.
    /// </para><ul><li><para>
    /// CFN Stack Name with a maximum length of 128 characters and prefix <c>athenafederatedcatalog-CATALOG_NAME_SANITIZED</c>
    /// with length 23 characters.
    /// </para></li><li><para>
    /// Lambda Function Name with a maximum length of 64 characters and prefix <c>athenafederatedcatalog_CATALOG_NAME_SANITIZED</c>
    /// with length 23 characters.
    /// </para></li><li><para>
    /// Glue Connection Name with a maximum length of 255 characters and a prefix <c>athenafederatedcatalog_CATALOG_NAME_SANITIZED</c>
    /// with length 23 characters. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "ATHDataCatalog", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Athena.Model.CreateDataCatalogResponse")]
    [AWSCmdlet("Calls the Amazon Athena CreateDataCatalog API operation.", Operation = new[] {"CreateDataCatalog"}, SelectReturnType = typeof(Amazon.Athena.Model.CreateDataCatalogResponse))]
    [AWSCmdletOutput("Amazon.Athena.Model.CreateDataCatalogResponse",
        "This cmdlet returns an Amazon.Athena.Model.CreateDataCatalogResponse object containing multiple properties."
    )]
    public partial class NewATHDataCatalogCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the data catalog to be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the data catalog to create. The catalog name must be unique for the Amazon
        /// Web Services account and can use a maximum of 127 alphanumeric, underscore, at sign,
        /// or hyphen characters. The remainder of the length constraint of 256 is reserved for
        /// use by Athena.</para><para>For <c>FEDERATED</c> type the catalog name has following considerations and limits:</para><ul><li><para>The catalog name allows special characters such as <c>_ , @ , \ , - </c>. These characters
        /// are replaced with a hyphen (-) when creating the CFN Stack Name and with an underscore
        /// (_) when creating the Lambda Function and Glue Connection Name.</para></li><li><para>The catalog name has a theoretical limit of 128 characters. However, since we use
        /// it to create other resources that allow less characters and we prepend a prefix to
        /// it, the actual catalog name limit for <c>FEDERATED</c> catalog is 64 - 23 = 41 characters.</para></li></ul>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Specifies the Lambda function or functions to use for creating the data catalog. This
        /// is a mapping whose values depend on the catalog type. </para><ul><li><para>For the <c>HIVE</c> data catalog type, use the following syntax. The <c>metadata-function</c>
        /// parameter is required. <c>The sdk-version</c> parameter is optional and defaults to
        /// the currently supported version.</para><para><c>metadata-function=<i>lambda_arn</i>, sdk-version=<i>version_number</i></c></para></li><li><para>For the <c>LAMBDA</c> data catalog type, use one of the following sets of required
        /// parameters, but not both.</para><ul><li><para>If you have one Lambda function that processes metadata and another for reading the
        /// actual data, use the following syntax. Both parameters are required.</para><para><c>metadata-function=<i>lambda_arn</i>, record-function=<i>lambda_arn</i></c></para></li><li><para> If you have a composite Lambda function that processes both metadata and data, use
        /// the following syntax to specify your Lambda function.</para><para><c>function=<i>lambda_arn</i></c></para></li></ul></li><li><para>The <c>GLUE</c> type takes a catalog ID parameter and is required. The <c><i>catalog_id</i></c> is the account ID of the Amazon Web Services account to which the Glue Data Catalog
        /// belongs.</para><para><c>catalog-id=<i>catalog_id</i></c></para><ul><li><para>The <c>GLUE</c> data catalog type also applies to the default <c>AwsDataCatalog</c>
        /// that already exists in your account, of which you can have only one and cannot modify.</para></li></ul></li><li><para>The <c>FEDERATED</c> data catalog type uses one of the following parameters, but not
        /// both. Use <c>connection-arn</c> for an existing Glue connection. Use <c>connection-type</c>
        /// and <c>connection-properties</c> to specify the configuration setting for a new connection.</para><ul><li><para><c>connection-arn:<i>&lt;glue_connection_arn_to_reuse&gt;</i></c></para></li><li><para><c>lambda-role-arn</c> (optional): The execution role to use for the Lambda function.
        /// If not provided, one is created.</para></li><li><para><c>connection-type:MYSQL|REDSHIFT|...., connection-properties:"<i>&lt;json_string&gt;</i>"</c></para><para>For <i><c>&lt;json_string&gt;</c></i>, use escaped JSON text, as in the following
        /// example.</para><para><c>"{\"spill_bucket\":\"my_spill\",\"spill_prefix\":\"athena-spill\",\"host\":\"abc12345.snowflakecomputing.com\",\"port\":\"1234\",\"warehouse\":\"DEV_WH\",\"database\":\"TEST\",\"schema\":\"PUBLIC\",\"SecretArn\":\"arn:aws:secretsmanager:ap-south-1:111122223333:secret:snowflake-XHb67j\"}"</c></para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of comma separated tags to add to the data catalog that is created. All the
        /// resources that are created by the <c>CreateDataCatalog</c> API operation with <c>FEDERATED</c>
        /// type will have the tag <c>federated_athena_datacatalog="true"</c>. This includes the
        /// CFN Stack, Glue Connection, Athena DataCatalog, and all the resources created as part
        /// of the CFN Stack (Lambda Function, IAM policies/roles).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Athena.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of data catalog to create: <c>LAMBDA</c> for a federated catalog, <c>GLUE</c>
        /// for an Glue Data Catalog, and <c>HIVE</c> for an external Apache Hive metastore. <c>FEDERATED</c>
        /// is a federated catalog for which Athena creates the connection and the Lambda function
        /// for you based on the parameters that you pass.</para><para>For <c>FEDERATED</c> type, we do not support IAM identity center.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Athena.DataCatalogType")]
        public Amazon.Athena.DataCatalogType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.CreateDataCatalogResponse).
        /// Specifying the name of a property of type Amazon.Athena.Model.CreateDataCatalogResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ATHDataCatalog (CreateDataCatalog)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.CreateDataCatalogResponse, NewATHDataCatalogCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (System.String)(this.Parameter[hashKey]));
                }
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Athena.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Athena.Model.CreateDataCatalogRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Athena.Model.CreateDataCatalogResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.CreateDataCatalogRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "CreateDataCatalog");
            try
            {
                return client.CreateDataCatalogAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public List<Amazon.Athena.Model.Tag> Tag { get; set; }
            public Amazon.Athena.DataCatalogType Type { get; set; }
            public System.Func<Amazon.Athena.Model.CreateDataCatalogResponse, NewATHDataCatalogCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
